using DoAn_CauLong.Models;
using DoAn_CauLong.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLDN_CauLong.Controllers
{
    public class HomeController : Controller
    {
        private Model1 data = new Model1();
        public ActionResult Index()
        {
            var sp = data.SanPhams
                        .Include("LoaiSanPham")
                        .ToList();
            return View(sp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Rô nao đô GOAT";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Action mới: Hiển thị chi tiết sản phẩm
        public ActionResult ChiTietSanPham(int id)
        {
            // 1. Lấy dữ liệu Sản phẩm chính và các mối quan hệ cần thiết
            var sanPham = data.SanPhams
                .Include(sp => sp.Hang)
                .Include(sp => sp.KhuyenMai)
                .FirstOrDefault(sp => sp.MaSanPham == id);

            if (sanPham == null)
            {
                return HttpNotFound();
            }

            // 2. Lấy tất cả biến thể chi tiết (ChiTietSanPham) kèm Màu và Size
            var variants = data.ChiTietSanPhams
                .Where(cts => cts.MaSanPham == id)
                .Include(cts => cts.MauSac) // Kế thừa từ Model1.cs
                .Include(cts => cts.Size)    // Kế thừa từ Model1.cs
                .Include(cts => cts.ThongSoVots) // Lấy thông số vợt (nếu có)
                .ToList();

            // 3. Lấy thông tin Đánh giá
            var reviews = data.PhanHois
                .Where(ph => ph.MaSanPham == id)
                .ToList();

            double averageRating = reviews.Any() ? reviews.Average(ph => (double)ph.DanhGia) : 0;
            int reviewCount = reviews.Count();

            // 4. Chuẩn bị ViewModel
            var viewModel = new ProductDetailViewModel
            {
                SanPham = sanPham,
                Variants = variants,
                AverageRating = averageRating,
                ReviewCount = reviewCount,
                // Lấy các tùy chọn duy nhất để hiển thị nút
                AvailableColors = variants.Where(v => v.MauSac != null).Select(v => v.MauSac).Distinct().ToList(),
                AvailableSizes = variants.Where(v => v.Size != null).Select(v => v.Size).Distinct().ToList(),
            };

            // 5. Truyền ViewModel sang View
            return View(viewModel);
        }

        //Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public ActionResult AddToCart(int chiTietId, int quantity)
        {
            // 1. KIỂM TRA ĐĂNG NHẬP (Thủ công)
            if (!User.Identity.IsAuthenticated)
            {
                string returnUrl = Request.Url?.ToString() ?? Url.Action("Index", "Home");
                return RedirectToAction("Login", "Account", new { returnUrl = returnUrl });
            }

            // 2. Lấy MaKhachHang hiện tại (Giả định bạn có cách lấy MaKhachHang từ User.Identity.Name)
            // Đây là bước quan trọng nhất khi dùng DB Entity:
            int maKhachHang = GetMaKhachHangFromLoggedInUser(User.Identity.Name); // Bạn cần tự implement hàm này

            // 3. Tìm xem mục hàng đã có trong DB chưa
            var existingCartItem = data.GioHangs
                .SingleOrDefault(g => g.MaKhachHang == maKhachHang && g.MaChiTietSanPham == chiTietId);

            if (existingCartItem == null)
            {
                // A. Mục hàng chưa tồn tại: Tạo mới
                var newCartItem = new GioHang
                {
                    MaKhachHang = maKhachHang,
                    MaChiTietSanPham = chiTietId,
                    SoLuong = quantity,
                    NgayThem = DateTime.Now
                };
                data.GioHangs.Add(newCartItem);
            }
            else
            {
                // B. Mục hàng đã tồn tại: Cập nhật số lượng
                existingCartItem.SoLuong += quantity;
                existingCartItem.NgayThem = DateTime.Now; // Cập nhật thời gian
                data.Entry(existingCartItem).State = EntityState.Modified;
            }

            data.SaveChanges();
            TempData["SuccessMessage"] = "Đã thêm sản phẩm vào giỏ hàng!";
            return RedirectToAction("ViewCart");
        }

        // Hàm giả định để lấy MaKhachHang từ tên đăng nhập (bạn phải tự implement)
        private int GetMaKhachHangFromLoggedInUser(string userName)
        {
            // Logic tìm MaKhachHang trong bảng TaiKhoan hoặc KhachHang dựa trên tên đăng nhập
            // Ví dụ: return data.TaiKhoans.Single(t => t.TenDangNhap == userName).MaKhachHang.Value;
            // TẠM THỜI TRẢ VỀ 1 ĐỂ TEST:
            return 1;
        }

        public ActionResult ViewCart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu chưa đăng nhập, không thể xem giỏ hàng vĩnh viễn (redirect)
                return RedirectToAction("Login", "Account");
            }

            int maKhachHang = GetMaKhachHangFromLoggedInUser(User.Identity.Name);

            // 1. Truy vấn GioHang Entity và các Navigation Property cần thiết
            var cartItemsFromDb = data.GioHangs
                .Where(g => g.MaKhachHang == maKhachHang)
                .Include(g => g.ChiTietSanPham)
                .Include(g => g.ChiTietSanPham.SanPham) // Cần để lấy TenSanPham
                .Include(g => g.ChiTietSanPham.MauSac) // Cần để lấy TenMau
                .Include(g => g.ChiTietSanPham.Size) // Cần để lấy TenSize
                .OrderByDescending(g => g.NgayThem)
                .ToList();

            // 2. Ánh xạ sang ViewModel (CartItemViewModel)
            var cartViewModels = cartItemsFromDb.Select(g => new CartItemViewModel
            {
                MaGioHang = g.MaGioHang,
                MaChiTietSanPham = g.MaChiTietSanPham.Value,
                SoLuong = g.SoLuong.Value,

                // Ánh xạ các trường hiển thị
                TenSanPham = g.ChiTietSanPham.SanPham?.TenSanPham,
                GiaBan = g.ChiTietSanPham.GiaBan ?? 0,
                HinhAnh = g.ChiTietSanPham.HinhAnh ?? g.ChiTietSanPham.SanPham?.HinhAnhDaiDien,
                TenMau = g.ChiTietSanPham.MauSac?.TenMau,
                TenSize = g.ChiTietSanPham.Size?.TenSize
            }).ToList();

            return View(cartViewModels);
        }
    }
}
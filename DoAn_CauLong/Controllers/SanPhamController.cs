using DoAn_CauLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DoAn_CauLong.Controllers
{
    public class SanPhamController : Controller
    {
        private Model1 data = new Model1();
        // GET: SanPham
        public ActionResult ViewAllProduct(int maLoai)
        {
            // 1. Lấy tên loại sản phẩm để hiển thị trên tiêu đề trang
            var loaiSanPham = data.LoaiSanPhams
                .SingleOrDefault(l => l.MaLoai == maLoai);

            if (loaiSanPham == null)
            {
                return HttpNotFound();
            }

            // 2. Lấy tất cả sản phẩm thuộc loại này
            var sanPhams = data.SanPhams
                .Where(sp => sp.MaLoai == maLoai)
                .Include(sp => sp.LoaiSanPham) // Tùy chọn: Bao gồm thông tin loại nếu cần
                .ToList();

            // 3. Truyền danh sách sản phẩm và tên loại vào View
            ViewBag.TenLoai = loaiSanPham.TenLoai;
            return View(sanPhams);
        }
    }
}
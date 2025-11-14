using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAn_CauLong.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LichSuThayDoiGia> LichSuThayDoiGias { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LogLoiGiaoTac> LogLoiGiaoTacs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongSoVot> ThongSoVots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.GiaBan)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.SKU)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSanPham>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietSanPham>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithOptional(e => e.ChiTietSanPham)
                .HasForeignKey(e => e.MaChiTietSanPham);

            modelBuilder.Entity<ChiTietSanPham>()
                .HasMany(e => e.GioHangs)
                .WithOptional(e => e.ChiTietSanPham)
                .HasForeignKey(e => e.MaChiTietSanPham);

            modelBuilder.Entity<ChiTietSanPham>()
                .HasMany(e => e.LichSuThayDoiGias)
                .WithRequired(e => e.ChiTietSanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTien)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTienSauGiam)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TienGiam)
                .HasPrecision(15, 2);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SoDienThoaiNhanHang)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.PhanTramGiam)
                .HasPrecision(5, 2);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.GiamToiDa)
                .HasPrecision(15, 2);

            modelBuilder.Entity<LichSuThayDoiGia>()
                .Property(e => e.GiaCu)
                .HasPrecision(15, 2);

            modelBuilder.Entity<LichSuThayDoiGia>()
                .Property(e => e.GiaMoi)
                .HasPrecision(15, 2);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaGoc)
                .HasPrecision(15, 2);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.HinhAnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietSanPhams)
                .WithOptional(e => e.SanPham)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Size>()
                .Property(e => e.TenSize)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ThongSoVot>()
                .Property(e => e.TrongLuong)
                .IsUnicode(false);
        }
    }
}

namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaChiTietSanPham { get; set; }

        public int? SoLuong { get; set; }

        public DateTime? NgayThem { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}

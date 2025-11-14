namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaDonHang { get; set; }

        public int? MaChiTietSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public decimal? ThanhTien { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}

namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuThayDoiGia")]
    public partial class LichSuThayDoiGia
    {
        [Key]
        public int MaLichSu { get; set; }

        public int MaChiTiet { get; set; }

        public decimal GiaCu { get; set; }

        public decimal GiaMoi { get; set; }

        public int SoLuongCu { get; set; }

        public int SoLuongMoi { get; set; }

        public DateTime? ThoiGianThayDoi { get; set; }

        [StringLength(100)]
        public string NguoiThayDoi { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}

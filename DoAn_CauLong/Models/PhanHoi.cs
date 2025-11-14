namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        public int MaPhanHoi { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public DateTime? NgayPhanHoi { get; set; }

        public int? DanhGia { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaSanPham { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

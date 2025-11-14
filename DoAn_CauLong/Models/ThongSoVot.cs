namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoVot")]
    public partial class ThongSoVot
    {
        [Key]
        public int MaThongSo { get; set; }

        public int? MaChiTiet { get; set; }

        [StringLength(50)]
        public string DoCanBang { get; set; }

        [StringLength(20)]
        public string TrongLuong { get; set; }

        [StringLength(50)]
        public string DoCung { get; set; }

        [StringLength(20)]
        public string ChieuDai { get; set; }

        [StringLength(20)]
        public string SucCang { get; set; }

        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}

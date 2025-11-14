namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int MaDonHang { get; set; }

        public DateTime? NgayDat { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public decimal? TongTien { get; set; }

        public decimal? TongTienSauGiam { get; set; }

        public int? MaKhachHang { get; set; }

        public decimal? TienGiam { get; set; }

        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(15)]
        public string SoDienThoaiNhanHang { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}

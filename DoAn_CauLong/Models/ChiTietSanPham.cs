namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietSanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            GioHangs = new HashSet<GioHang>();
            LichSuThayDoiGias = new HashSet<LichSuThayDoiGia>();
            ThongSoVots = new HashSet<ThongSoVot>();
        }

        [Key]
        public int MaChiTiet { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaMau { get; set; }

        public int? MaSize { get; set; }

        public decimal? GiaBan { get; set; }

        public int? SoLuongTon { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual Size Size { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuThayDoiGia> LichSuThayDoiGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongSoVot> ThongSoVots { get; set; }
    }
}

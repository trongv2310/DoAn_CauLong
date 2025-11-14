namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            PhanHois = new HashSet<PhanHoi>();
        }

        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSanPham { get; set; }

        public string MoTa { get; set; }

        public decimal? GiaGoc { get; set; }

        [StringLength(255)]
        public string HinhAnhDaiDien { get; set; }

        public int? MaLoai { get; set; }

        public int? MaNhaCungCap { get; set; }

        public int? MaHang { get; set; }

        public int? MaKhuyenMai { get; set; }

        public bool? CoSize { get; set; }

        public bool? CoMau { get; set; }

        public DateTime? NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
    }
}

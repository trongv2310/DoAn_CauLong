namespace DoAn_CauLong.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogLoiGiaoTac")]
    public partial class LogLoiGiaoTac
    {
        [Key]
        public int MaLog { get; set; }

        public int? MaChiTiet { get; set; }

        [StringLength(1000)]
        public string Loi { get; set; }

        public DateTime? ThoiGian { get; set; }

        [StringLength(100)]
        public string NguoiThucHien { get; set; }
    }
}

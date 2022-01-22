namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPham")]
    public partial class DanhMucSanPham
    {
        [Key]
        public int MaDMSP { get; set; }

        public int? MaDM { get; set; }

        public int? MaSP { get; set; }

        [StringLength(250)]
        public string TieuDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThayDoi { get; set; }

        public bool TrangThai { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

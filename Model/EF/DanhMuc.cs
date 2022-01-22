namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        [Key]
        public int MaDM { get; set; }

        [Required]
        [StringLength(250)]
        public string TenDM { get; set; }

        [StringLength(250)]
        public string TieuDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThayDoi { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}

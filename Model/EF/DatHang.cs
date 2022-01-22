namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatHang")]
    public partial class DatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatHang()
        {
            CT_DatHang = new HashSet<CT_DatHang>();
        }

        [Key]
        public int MaHD { get; set; }

        public int MaNV { get; set; }

        public DateTime NgayMua { get; set; }

        public DateTime? NgayGiao { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatHang> CT_DatHang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}

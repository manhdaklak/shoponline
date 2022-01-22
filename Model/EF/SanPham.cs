namespace Model.EF
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
            CT_DatHang = new HashSet<CT_DatHang>();
            CT_SanPham = new HashSet<CT_SanPham>();
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
            GioHangs = new HashSet<GioHang>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required(ErrorMessage ="Vui lòng chọn ảnh sản phẩm")]
        [StringLength(300)]
        public string AnhSP { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập tên")]
        [StringLength(300)]
        public string TenSP { get; set; }

        [StringLength(250)]
        public string TieuDeSP { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập số lượng")]
        public int SoLuong { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Vui lòng nhập đơn giá")]
        public decimal? DonGia { get; set; }

        [Column(TypeName = "text")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Vui chọn nhà cung cấp")]
        public int MaNCC { get; set; }

        public DateTime? NgayNhap { get; set; }

        public DateTime? NgayThayDoi { get; set; }

        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatHang> CT_DatHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_SanPham> CT_SanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}

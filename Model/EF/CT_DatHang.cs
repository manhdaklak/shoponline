namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DatHang
    {
        [Key]
        [StringLength(10)]
        public string MaChiTiet { get; set; }

        public int MaHD { get; set; }

        public int MaSP { get; set; }

        public int? MaChiTietSP { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? ChietKhau { get; set; }

        [Column(TypeName = "money")]
        public decimal? ThanhTien { get; set; }

        public virtual CT_SanPham CT_SanPham { get; set; }

        public virtual DatHang DatHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class SanPhamModel
    {
        public int MaSP { get; set; }
        public string AnhSP { get; set; }
        public string TenSP { get; set; }
        public string TieuDeSP { get; set; }

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string MoTa { get; set; }

        public int MaNCC { get; set; }

        public DateTime? NgayNhap { get; set; }

        public DateTime? NgayThayDoi { get; set; }

        public bool? TrangThai { get; set; }
    }
}

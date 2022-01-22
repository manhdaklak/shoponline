using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    [Serializable]
    public class GioHangModel
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}
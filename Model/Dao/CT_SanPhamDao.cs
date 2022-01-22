using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CT_SanPhamDao
    {
        OnlineShopDbContext db = null;
        public CT_SanPhamDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<CT_SanPham> GetCT_SanPhams(long id)
        {
            return db.CT_SanPham.Where(ct => ct.MaSP == id).ToList();
        }
        
    }
}

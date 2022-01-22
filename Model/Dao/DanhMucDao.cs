using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DanhMucDao
    {
        OnlineShopDbContext db = null;
        public DanhMucDao()
        {
            db = new OnlineShopDbContext();
        }
        
    }
}

using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NguoiDungDao
    {
        OnlineShopDbContext db = null;

        public NguoiDungDao()
        {
            db = new OnlineShopDbContext();
        }

        public IEnumerable<NguoiDung> GetAll_NguoiDung(int page, int pagesize)
        {
            IQueryable<NguoiDung> model = db.NguoiDungs;
           
            return model.OrderByDescending(x => x.TenND).ToPagedList(page,pagesize);
        }
        public bool KiemTra_TrangThai(int id)
        {
            var nd = db.NguoiDungs.Find(id);
            nd.TrangThai = !nd.TrangThai;
            db.SaveChanges();

            return nd.TrangThai;
        }

        public void Insert<T>(T model) where T: class
        {
            using (var ct = new OnlineShopDbContext())
            {
                ct.Set<T>().Add(model);
                ct.SaveChanges();
            }
        }
        public NguoiDung GetNguoDung(long id)
        {
            return db.NguoiDungs.Where(x => x.MaND == id).FirstOrDefault();
        }
        public bool CapNhatNguoiDung(NguoiDung nd)
        {
            try
            {
                var n = db.NguoiDungs.Find(nd.MaND);
                n.TenND = nd.TenND;
                if (!string.IsNullOrEmpty(nd.MatKhau))
                {
                    n.MatKhau = nd.MatKhau;
                }
                n.SDT = nd.SDT;
                n.Email = nd.Email;
                n.DiaChi = nd.DiaChi;
                n.NgayThayDoi = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public void XoaNguoDung<T>(T obj)
        {
            db.Set(obj.GetType()).Remove(obj);
        }
       
        public void Save()
        {
            db.SaveChanges();
        }
    }
}

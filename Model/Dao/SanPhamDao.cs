using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SanPhamDao
    {
        OnlineShopDbContext db = null;
        public SanPhamDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<SanPham> GetAll_SanPham(int top)
        {
            var result = db.SanPhams.OrderByDescending(s => s.NgayNhap).Take(top).ToList();
           // var result = db.SanPhams.OrderByDescending(s => s.TenSP).ToList();
            return result;
        }
        public List<SanPham> GetAll_SanPham()
        {
            var result = db.SanPhams.OrderByDescending(s => s.TenSP).ToList();
            return result;
        }
        public IEnumerable<SanPham> GetAll_PageList(string searchString, int page, int pagesize)
        {
            IQueryable<SanPham> sp = db.SanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                sp = sp.Where(s => s.TenSP.Contains(searchString));
            }
            return sp.OrderByDescending(s => s.TenSP).ToPagedList(page, pagesize);
        }

        public SanPham Get_MaSanPham(long id)
        {
            return db.SanPhams.Find(id);
        }
        public SanPham GetSanPham(long id)
        {
            return db.SanPhams.Where(s => s.MaSP == id).FirstOrDefault();
        }
        public IQueryable<CT_SanPham> Get_CTSP(long id)
        {
            var result = from sp in db.SanPhams
                         join ct in db.CT_SanPham on
                         sp.MaSP equals ct.MaSP   
                         where sp.MaSP == id
                         select ct;

            return result;
        }
        public void Insert<T>(T model) where T: class
        {
            using(var ct = new OnlineShopDbContext())
            {
                ct.Set<T>().Add(model);
                ct.SaveChanges();
            }
        }
        public List<DanhMuc> ListDanhMuc()
        {
            return db.DanhMucs.OrderByDescending(s=>s.TrangThai==true).ToList();
        }
        public List<NhaCungCap> ListNhaCC()
        {
            return db.NhaCungCaps.OrderByDescending(x=>x.TenNCC).ToList();
        }
    }
}

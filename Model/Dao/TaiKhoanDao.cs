using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TaiKhoanDao
    {
        OnlineShopDbContext db = null;
        public TaiKhoanDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert_NguoiDung(NguoiDung nd)
        {
            db.NguoiDungs.Add(nd);
            db.SaveChanges();
            return nd.MaND;
        }
        public bool CheckTenDangNhap(string tenDN)
        {
            return db.NguoiDungs.Count(nd => nd.TenDangNhap == tenDN) > 0;
        }

        public bool CheckSDT(string sdt)
        {
            return db.NguoiDungs.Count(nd => nd.SDT == sdt) > 0;
        }

        public NguoiDung GetMa_NguoiDung(string tenDN)
        {
            return db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == tenDN);
        }

        public int DangNhap(string tenDN, string matkhau)
        {
            var result = db.NguoiDungs.FirstOrDefault(x => x.TenDangNhap == tenDN);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.TrangThai == false)
                {
                    return -1;
                }
                else
                {
                    if (result.MatKhau == matkhau)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }

                }

            }
        }
    }
}

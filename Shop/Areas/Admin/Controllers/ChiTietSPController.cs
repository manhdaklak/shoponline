using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class ChiTietSPController : BaseController
    {
        // GET: Admin/ChiTietSP
        public ActionResult ChiTiet()
        {

            return View();
        }

         [HttpGet]
        public ActionResult ThemChiTiet()
        {
            //var dao = new SanPhamDao();
            //var result = dao.Get_MaSanPham(id);
            //var model = result.MaSP;
            return View();
        }
        [HttpPost]
        public ActionResult ThemChiTiet(CT_SanPham model)
        {
            var dao = new SanPhamDao();
            var sp = new SanPham();
            var result = dao.Get_MaSanPham(sp.MaSP);
            if (ModelState.IsValid)
            {
                var ct = new CT_SanPham();
                ct.MaSP = Convert.ToInt32( result);
                ct.MauSac = model.MauSac;
                ct.Size = model.Size;
                ct.SoLuong = model.SoLuong;

                if(ct != null)
                {
                    dao.Insert<CT_SanPham>(ct);
                    RedirectToAction("/Admin/ChiTietSP/ThemChiTiet");
                }
            
            }
                
            return View();
        }
    }
}
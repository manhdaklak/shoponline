using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult SanPham(string searchString, int page =1, int pagesize=9)
        {
            var spDao = new SanPhamDao();
            
            var model = spDao.GetAll_PageList(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult CTSanPham(long id)
        {
            var spDao = new SanPhamDao();
            var result = spDao.Get_MaSanPham(id);
            var model = new SanPhamDao().GetSanPham(result.MaSP);
            ViewBag.SanPham_CT = spDao.GetAll_SanPham();
            return View(model);
        }

        public ActionResult YeuThich()
        {
            return View();
        }
    }
}
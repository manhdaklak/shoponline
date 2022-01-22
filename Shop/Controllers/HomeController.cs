using Model.Dao;
using Model.EF;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int n = 6;
            var spDao = new SanPhamDao();
            List<SanPham> sp = spDao.GetAll_SanPham(n);
            return View(sp);
        }
        public PartialViewResult HeaderCart()
        {
            var session = Session[Util.Constants.CartSession];
            var list = new List<GioHangModel>();
            if (session != null)
            {
                list = (List<GioHangModel>)session;
            }
            return PartialView(list);
        }


    }
}
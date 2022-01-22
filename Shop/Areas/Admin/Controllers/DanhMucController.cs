using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class DanhMucController : BaseController
    {
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            var dao = new SanPhamDao();
            var model = dao.ListDanhMuc();
            return View(model);
        }
        [HttpPost]
        public ActionResult ThemDanhMuc(DanhMuc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var dm = new DanhMuc();
                dm.TenDM = model.TenDM;
                dm.TieuDe = model.TieuDe;

                if (dm != null)
                {
                    dao.Insert<DanhMuc>(dm);
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}
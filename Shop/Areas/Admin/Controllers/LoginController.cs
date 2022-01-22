using Model.Dao;
using Shop.Areas.Admin.Model;
using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DangNhapModel model)
        {
            var dao = new TaiKhoanDao();
            if (ModelState.IsValid)
            {
                var result = dao.DangNhap(model.TenDN, Util.Util.Encrypt(model.MatKhau));
                var nd = dao.GetMa_NguoiDung(model.TenDN);
                var session = new ND_DangNhap();
                if (result == 1)
                {
                    session.TenDangNhap = nd.TenDangNhap;
                    session.MaND = nd.MaND;
                    session.ten = nd.TenND;
                    Session.Add(Util.Constants.USER_SESSION, session);
                    return Redirect("/Admin/Home/Index");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                    return RedirectToAction("Index");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                   
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                  
                }


            }
            return View(model);
        }
        public ActionResult DangXuat()
        {
            Session[Util.Constants.USER_SESSION] =null;
            return Redirect("/Admin/Login/Index");
        }
        public ActionResult ResetMatKhau()
        {
            return View();
        }
    }
}
using Model.Dao;
using Model.EF;
using Shop.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan

        [HttpGet]
        public ActionResult TaiKhoan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(LoginModel model)
        {
            var dao = new TaiKhoanDao();
            //  var result = dao.DangNhap(model.TenDN, Util.Util.Encrypt((model.MatKhau)));
         
             if (ModelState.IsValid)
            {
                var result = dao.DangNhap(model.TenDN, Util.Util.Encrypt((model.MatKhau)));
                var nguoidung = dao.GetMa_NguoiDung(model.TenDN);
                var session = new ND_DangNhap();
                if (result == 1)
                {

                    session.TenDangNhap = nguoidung.TenDangNhap;
                    session.MaND = nguoidung.MaND;
                    session.ten = nguoidung.TenND;
                    Session.Add(Util.Constants.USER_SESSION, session);
                    return Redirect("/");
                }

                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
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
            Session[Util.Constants.USER_SESSION] = null;
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                if (dao.CheckTenDangNhap(model.TenDangNhap))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckSDT(model.SDT))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }
                else
                {
                    var nd = new NguoiDung();
                    nd.TenND = model.Ho + "" + model.Ten;
                    nd.SDT = model.SDT;
                    nd.Email = model.Email;
                    nd.TenDangNhap = model.TenDangNhap;
                    nd.MatKhau = Util.Util.Encrypt(model.MatKhau);
                    nd.DiaChi = model.DiaChi;
                    nd.NgayTao = DateTime.Now;
                    nd.TrangThai = true;

                    var result = dao.Insert_NguoiDung(nd);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công!";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }
    }
}
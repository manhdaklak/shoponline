using Model.Dao;
using Model.EF;
using Shop.Areas.Admin.Model;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class NguoiDungController : BaseController
    {
        // GET: Admin/NguoiDung
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var nguoidung = new NguoiDungDao();
            var model = nguoidung.GetAll_NguoiDung(page, pagesize);
            return View(model);
        }

        [HttpPost]
        public JsonResult TrangThai(int id)
        {
            var result = new NguoiDungDao().KiemTra_TrangThai(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        public ActionResult ThemNguoiDung()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNguoiDung(NguoiDungModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDao();
                var dao1 = new TaiKhoanDao();
                if (dao1.CheckTenDangNhap(model.TenDangNhap))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao1.CheckSDT(model.SDT))
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

                    if (nd != null)
                    {
                        dao.Insert<NguoiDung>(nd);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công");
                    }
                }

            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CapNhat(int id)
        {
            var model = new NguoiDungDao().GetNguoDung(id);
            model.MatKhau = Util.Util.Decrypt(model.MatKhau);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDao();
                if (!string.IsNullOrEmpty(nguoiDung.MatKhau))
                {
                    var encryted = Util.Util.Encrypt(nguoiDung.MatKhau);
                    nguoiDung.MatKhau = encryted;
                }

                var result = dao.CapNhatNguoiDung(nguoiDung);
                if (result == true)
                {
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }

            }
            return View();
        }
        /// <summary>
        /// Xóa một người dùng bằng ajax( chỉ sử dụng trên domain: http://shop.com)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(FormCollection data)
        {
            long id = Convert.ToInt64(data["id"]);
            JsonResult js = new JsonResult();
            if (id <=0)
            {
                js.Data = new
                {
                    status = "ER",
                    message = "Dữ liệu bị trống !"
                };
            }
            else
            {
                var dao = new NguoiDungDao();

                NguoiDung nd = dao.GetNguoDung(id);
                if(id <= 0)
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "Dữ liệu không tồn tại ! "
                    };
                }
                else
                {
                    dao.XoaNguoDung(nd);
                    dao.Save();
                    js.Data = new
                    {
                        status = "OK"

                    };
                }
               
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}
using Model.Dao;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        [HttpGet]
        public ActionResult GioHang()
        {
            var session = Session[Util.Constants.CartSession];
            var list = new List<GioHangModel>();
            if(session != null)
            {
                list = (List<GioHangModel>)session;
            }

            return View(list);
        }

        public ActionResult GioHang_1()
        {
            var session = Session[Util.Constants.CartSession];
            var list = new List<GioHangModel>();
            if (session != null)
            {
                list = (List<GioHangModel>)session;
            }

            return View(list);
        }
        public ActionResult ThemGioHang(long maSP, int soluong)
        {
            var sp = new SanPhamDao().Get_MaSanPham(maSP);
            var session = Session[Util.Constants.CartSession];

            if (session != null)
            {
                var list = (List<GioHangModel>)session;

                if (list.Exists(s => s.SanPham.MaSP == maSP))
                {
                    foreach(var item in list)
                    {
                        if (item.SanPham.MaSP == maSP)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    // tạo 1 đối tượng mới
                    var item = new GioHangModel();
                    item.SanPham = sp;
                    item.SoLuong = soluong;
                    list.Add(item);
                }
                // gán vào session
                Session[Util.Constants.CartSession] = list;
            }
            else
            {
                // tạo mới giỏ hàng
                var item = new GioHangModel();
                item.SanPham = sp;
                item.SoLuong = soluong;
                var list = new List<GioHangModel>();
                list.Add(item);

                // gán vào session
                Session[Util.Constants.CartSession] = list;
            }
            return RedirectToAction("GioHang");
        }

        public JsonResult TruHang(string cartModel)
        {
            var jsonGioHang = new JavaScriptSerializer().Deserialize<List<GioHangModel>>(cartModel);
            var session = (List<GioHangModel>)Session[Util.Constants.CartSession];

            foreach(var item in session)
            {
                var jsonItem = jsonGioHang.FirstOrDefault(sp => sp.SanPham.MaSP == item.SanPham.MaSP);
                if(jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[Util.Constants.CartSession] = session;
            return Json(new
            {
                status = true
            }) ;
        }
        public JsonResult CongHang(string cartModel)
        {
            var jsonGioHang = new JavaScriptSerializer().Deserialize<List<GioHangModel>>(cartModel);
            var session = (List<GioHangModel>)Session[Util.Constants.CartSession];

            foreach (var item in session)
            {
                var jsonItem = jsonGioHang.FirstOrDefault(sp => sp.SanPham.MaSP == item.SanPham.MaSP);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[Util.Constants.CartSession] = session;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Xoa(long id)
        {
            var session = (List<GioHangModel>)Session[Util.Constants.CartSession];
            session.RemoveAll(x => x.SanPham.MaSP == id);
            Session[Util.Constants.CartSession] = session;
            return Json(new
            {
                status = true
            }); ;
        }
        public ActionResult ThanhToan()
        {
            return View();
        }
    }
}
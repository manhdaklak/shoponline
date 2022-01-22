using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/SanPham
        [HttpGet]
        public ActionResult SanPham()
        {
            var dao = new SanPhamDao();
            var model = dao.GetAll_SanPham();
            return View(model);
        }
        [HttpGet]
        public ActionResult ChiTiet(long id)
        {
            var dao = new SanPhamDao();
            var sp = dao.Get_MaSanPham(id);
            var model = dao.Get_CTSP(sp.MaSP);
            ViewBag.MaSPP = sp.MaSP;
            return View(model);
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham model)
        {
           
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var sp = new SanPham();

                sp.AnhSP = model.AnhSP;
                sp.TenSP = model.TenSP;
                sp.TieuDeSP = model.TieuDeSP;
                if(model.SoLuong > 0)
                {
                    sp.SoLuong = model.SoLuong;
                }
                if(model.DonGia > 0)
                {
                    sp.DonGia = model.DonGia;
                }
                sp.MoTa = model.MoTa;
                sp.MaNCC = model.MaNCC;
                sp.NgayNhap = DateTime.Now;
                sp.TrangThai = true;

                if(sp != null)
                {
                    dao.Insert<SanPham>(sp);
                    return RedirectToAction("ThemSanPham");
                }
                else
                {
                    ModelState.AddModelError("","Thêm không thành công");
                }
            }
            return View();
        } 
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new SanPhamDao();
            ViewBag.NhaCC = new SelectList(dao.ListNhaCC(), "MaNCC", "TenNCC", selectedId);
        }
       
    }
}
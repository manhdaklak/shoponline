using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "DangKy",
               url: "dang-ky",
               defaults: new { controller = "TaiKhoan", action = "DangKy", id = UrlParameter.Optional }
              ,namespaces: new[] { "Shop.Controllers" }
               );
            routes.MapRoute(
               name: "DangNhap",
               url: "dang-nhap",
               defaults: new { controller = "TaiKhoan", action = "DangNhap", id = UrlParameter.Optional }
                , namespaces: new[] { "Shop.Controllers" }
               );
            routes.MapRoute(
               name: "DangXuat",
               url: "dang-xuat",
               defaults: new { controller = "TaiKhoan", action = "DangXuat", id = UrlParameter.Optional }
                , namespaces: new[] { "Shop.Controllers"}
               );
            routes.MapRoute(
              name: "SanPham",
              url: "san-pham",
              defaults: new { controller = "SanPham", action = "SanPham", id = UrlParameter.Optional }
            , namespaces: new[] { "Shop.Controllers" }
              );
            routes.MapRoute(
            name: "San Pham",
            url: "san-pham/{tieude}-{id}",
            defaults: new { controller = "SanPham", action = "SanPham", id = UrlParameter.Optional }
            , namespaces: new[] { "Shop.Controllers" }
            );
           routes.MapRoute(
           name: "Chi tiet San Pham",
           url: "chi-tiet/{tieude}-{id}",
           defaults: new { controller = "SanPham", action = "CTSanPham", id = UrlParameter.Optional }
            , namespaces: new[] { "Shop.Controllers" }
           );
            routes.MapRoute(
            name: "Gio Hang",
            url: "gio-hang",
            defaults: new { controller = "GioHang", action = "GioHang", id = UrlParameter.Optional }
            , namespaces: new[] { "Shop.Controllers" }
            );
            routes.MapRoute(
            name: "Them Gio Hang",
            url: "them-gio-hang",
            defaults: new { controller ="GioHang", action = "ThemGioHang", id = UrlParameter.Optional }
            , namespaces: new[] { "Shop.Controllers" }
            );
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[]{ "Shop.Controllers" }
          );
        }
    }
}

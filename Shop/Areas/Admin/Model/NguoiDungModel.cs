using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Model
{
    public class NguoiDungModel
    {
        [Key]
        public long MaND { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng nhập họ")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Họ không hợp lệ")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Tên Không hợp lệ")]
        public string Ten { get; set; }

        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$", ErrorMessage = "Kí tự đầu phải viết hoa")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 8 ký tự.")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }


        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        public string XNMatKhau { get; set; }


        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email nhập không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]

        public string SDT { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        public DateTime Ngaytao { get; set; }
        public String Ho_Ten()
        {
            return this.Ho + "" + this.Ten;
        }
    }
}
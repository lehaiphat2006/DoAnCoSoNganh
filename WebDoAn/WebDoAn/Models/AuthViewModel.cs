using System.ComponentModel.DataAnnotations;

namespace WebDoAn.Models
{
    //public class AuthViewModel
    //{
    //}
    public class DangNhapViewModel
    {
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; } = "";

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; } = "";
    }

    public class DangKyViewModel
    {
        [Required(ErrorMessage = "Nhập họ tên")]
        [StringLength(100)]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; } = "";

        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Tên đăng nhập từ 4 đến 50 ký tự")]
        [RegularExpression(@"^[A-Za-z0-9_.]+$", ErrorMessage = "Chỉ dùng chữ không dấu, số, dấu . và _")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; } = "";

        [Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; } = "";

        [Required(ErrorMessage = "Nhập lại mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu nhập lại không khớp")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        public string XacNhanMatKhau { get; set; } = "";

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Chọn vai trò")]
        [Display(Name = "Vai trò")]
        public string VaiTro { get; set; } = "";
    }

    public class DoiMatKhauViewModel
    {
        [Required(ErrorMessage = "Nhập mật khẩu hiện tại")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string MatKhauCu { get; set; } = "";

        [Required(ErrorMessage = "Nhập mật khẩu mới")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string MatKhauMoi { get; set; } = "";

        [Required(ErrorMessage = "Nhập lại mật khẩu mới")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật khẩu nhập lại không khớp")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        public string XacNhanMatKhauMoi { get; set; } = "";
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDoAn.Models
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        [Display(Name = "Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }

        [Required(ErrorMessage = "Nhập tên nhà cung cấp")]
        [StringLength(150)]
        [Display(Name = "Tên nhà cung cấp")]
        public string TenNhaCungCap { get; set; }

        [StringLength(255)]
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Người liên hệ")]
        public string? NguoiLienHe { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã số thuế")]
        public string? MaSoThue { get; set; }

        [StringLength(100)]
        [Display(Name = "Điều khoản thanh toán")]
        public string? DieuKhoanThanhToan { get; set; }

        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "Đang hợp tác";

        //public List<DonMua> DonMuas { get; set; } = new();
    
    }
}

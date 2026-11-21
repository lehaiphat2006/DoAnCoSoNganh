using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDoAn.Models
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        [DisplayName("Mã Người Dùng")]
        public byte MaNguoiDung { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Tên Đăng Nhập")]
        public string TenDangNhap { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Mật Khẩu Mã Hóa")]
        public string MatKhauMaHoa { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Họ Tên")]
        public string HoTen { get; set; }
        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string? SoDienThoai { get; set; }
        [StringLength(100)]
        [DisplayName("Email")]
        public string? Email { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Vai Trò")]
        public string VaiTro { get; set; }
        [DisplayName("Kích Hoạt")]
        public bool KichHoat { get; set; }
    }
}

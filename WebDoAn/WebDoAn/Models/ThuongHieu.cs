using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDoAn.Models
{
    [Table("ThuongHieu")]
    public class ThuongHieu
    {
        [Key]
        [DisplayName("Mã Thương Hiệu")]
        public byte MaThuongHieu { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Tên Thương Hiệu")]
        public string TenThuongHieu { get; set; }
    }
}

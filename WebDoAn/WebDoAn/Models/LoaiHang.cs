using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDoAn.Models
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        [Key]
        [DisplayName("Mã Loại Hàng")]
        public byte MaLoaiHang { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Tên Loại Hàng")]
        public string TenLoaiHang { get; set; }
    }
}

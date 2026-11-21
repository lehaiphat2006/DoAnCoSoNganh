using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDoAn.Models
{
    [Table("DonViTinh")]
    public class DonViTinh
    {
        [Key]
        [DisplayName("Mã đơn vị tính")]
        public byte MaDonViTinh { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Tên đơn vị tính")]
        public string TenDonViTinh { get; set; }
    }
}

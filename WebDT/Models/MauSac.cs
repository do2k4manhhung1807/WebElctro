using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebDT.Models
{
    public class MauSac
    {
        [Key]
        public int MaMauSac { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên màu")]
        public string TenMau { get; set; }
        public IList<MauSacSanPham> MauSacSanPham { get; set; }
    }
}

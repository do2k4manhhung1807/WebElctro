using System.ComponentModel.DataAnnotations;

namespace WebDT.Models
{
    public class TrangThaiThanhToan
    {
        [Key]
        public int MaTrangThaiDonHang { get; set; }
        public string TenTrangThaiDonHang { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}

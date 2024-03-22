using System.ComponentModel.DataAnnotations;

namespace WebDT.Models
{
    public class TrangThaiThanhToan
    {
        [Key]
        public int MaTrangThaiThanhToan { get; set; }
        public string TenTrangThaiThanhToan { get; set; }
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}

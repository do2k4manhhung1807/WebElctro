using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace WebDT.Models
{
    public class BoNhoSanPham
    {
        [ForeignKey("BoNho")]
        public int MaBoNho { get; set; }
        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }
        public virtual BoNho BoNho { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}

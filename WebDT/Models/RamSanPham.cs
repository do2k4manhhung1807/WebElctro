using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDT.Models
{
    public class RamSanPham
    {

        [ForeignKey("Ram")]
        public int MaRam { get; set; }
        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
        public virtual Ram Ram { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDT.Models
{
    public class MauSacSanPham
    {

        [ForeignKey("MauSac")]
        public int MaMauSac { get; set; }
        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
        public virtual MauSac MauSac { get; set; }
    }
}

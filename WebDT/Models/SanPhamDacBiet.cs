using System.ComponentModel.DataAnnotations;

namespace WebDT.Models
{
    public class SanPhamDacBiet
    {
        [Key]
        public int MaSanPhamDacBiet { get; set; }   
        public string LoaiSanPhamDacBiet { get; set; }  
        public ICollection<SanPham> SanPham { get; set; }
    }
}

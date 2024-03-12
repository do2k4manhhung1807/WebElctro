using WebDT.Models;
namespace WebDT.ViewModel
{
    public class SanPhamChiTietViewModel
    {
        public List<Iphone> Iphone { get; set; }  
        public List<Ipad> Ipad { get; set; }
        public List<IMac> IMac { get; set; }
        public List<Laptop> Laptop { get; set; }
        public List<SanPham> SanPhamList { get; set; }
        public List<HinhAnh> HinhAnhList { get; set; }
    }
}
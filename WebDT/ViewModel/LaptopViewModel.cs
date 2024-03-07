using WebDT.Models;

namespace WebDT.ViewModel
{
    public class LaptopViewModel
    {
        public SanPham SanPham { get; set; }
        public Laptop Laptop { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}

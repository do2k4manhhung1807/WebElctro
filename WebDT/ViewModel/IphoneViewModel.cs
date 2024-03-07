using System.ComponentModel.DataAnnotations;
using WebDT.Models;
namespace WebDT.ViewModel
{
    public class IphoneViewModel
    {
        public SanPham SanPham { get; set; }
        public Iphone Phone { get; set; }
        public List<IFormFile> Images { get; set; }

    }
}

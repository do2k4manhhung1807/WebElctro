using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDT.Data;
using WebDT.Models;
using WebDT.ViewModel;

namespace WebDT.Controllers
{
    public class KiemTraDonHangController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public KiemTraDonHangController(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpPost]
        public IActionResult Index(string phoneNumber)
        {
            // Kiểm tra xem số điện thoại có trong đơn hàng không
            var donHang = _dataContext.DonHang.FirstOrDefault(d => d.SoDienThoai == phoneNumber);
            if (donHang != null)
            {
                // Nếu có, hiển thị thông tin đơn hàng
                return View("ThongTinDonHang", donHang);
            }
            else
            {
                // Nếu không, hiển thị thông báo số điện thoại không khả dụng
                ViewBag.Message = "Số điện thoại không khả dụng";
                return View("KiemTraDonHang");
            }
        }
    }
}

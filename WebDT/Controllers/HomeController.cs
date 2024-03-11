using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDT.Data;
using WebDT.Models;
using WebDT.ViewModel;

namespace WebDT.Controllers
{
    /*    [Authorize]
    */
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dataContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var sanPhamList = _dataContext.SANPHAM.ToList();
            var hinhAnhList = _dataContext.HINHANH.ToList();

            // T?o ViewModel và gán d? li?u
            var viewModel = new SanPhamChiTietViewModel
            {
                SanPhamList = sanPhamList,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

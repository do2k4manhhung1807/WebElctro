using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebDT.Data;
using WebDT.Models;

namespace WebDT.Controllers
{
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
            // L?y d? li?u t? c? s? d? li?u, ví d? l?y danh sách s?n ph?m
            var productList = _dataContext.SANPHAM.ToList();

            // Truy?n danh sách s?n ph?m vào View
            return View(productList);
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

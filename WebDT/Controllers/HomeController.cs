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
        public IActionResult XemThemSanPhamMoi(int maSanPhamDacBiet)
        {
            var sanPhamList = _dataContext.SANPHAM.Where(x => x.MaSanPhamDacBiet == maSanPhamDacBiet).ToList();
            var hinhAnhList = _dataContext.HINHANH.ToList();

            var viewModel = new SanPhamChiTietViewModel
            {
                SanPhamList = sanPhamList,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View("XemThemSanPhamMoi", viewModel);
        }
        public IActionResult XemThemSanPhamYeuThich(int maSanPhamDacBiet)
        {
            var sanPhamList = _dataContext.SANPHAM.Where(x => x.MaSanPhamDacBiet == maSanPhamDacBiet).ToList();
            var hinhAnhList = _dataContext.HINHANH.ToList();

            var viewModel = new SanPhamChiTietViewModel
            {
                SanPhamList = sanPhamList,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View("XemThemSanPhamYeuThich", viewModel);
        }
        public IActionResult XemThemSanPhamBanChay(int maSanPhamDacBiet)
        {
            var sanPhamList = _dataContext.SANPHAM.Where(x => x.MaSanPhamDacBiet == maSanPhamDacBiet).ToList();
            var hinhAnhList = _dataContext.HINHANH.ToList();

            var viewModel = new SanPhamChiTietViewModel
            {
                SanPhamList = sanPhamList,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View("XemThemSanPhamBanChay", viewModel);
        }
        public async Task<IActionResult> XemThemSanPhamIphone()
        {
           
            var iphone = await _dataContext.IPHONE.ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.ToListAsync();

            var viewModel = new SanPhamChiTietViewModel
            {
                Iphone = iphone,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View(viewModel);
        }

        public async Task<IActionResult> XemThemSanPhamIpad()
        {

            var ipad = await _dataContext.IPAD.ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.ToListAsync();

            var viewModel = new SanPhamChiTietViewModel
            {
                Ipad = ipad,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View(viewModel);
        }
        public async Task<IActionResult> XemThemSanPhamIMac()
        {

            var imac = await _dataContext.IMAC.ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.ToListAsync();

            var viewModel = new SanPhamChiTietViewModel
            {
                IMac = imac,
                HinhAnhList = hinhAnhList
            };

            // Truy?n ViewModel vào View
            return View(viewModel);
        }
        public async Task<IActionResult> XemThemSanPhamLaptop()
        {

            var laptop = await _dataContext.LAPTOP.ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.ToListAsync();

            var viewModel = new SanPhamChiTietViewModel
            {
                Laptop = laptop,
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

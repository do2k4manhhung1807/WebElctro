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

        public async Task<IActionResult> Index()
        {
            var sanPhamList = await _dataContext.SANPHAM.ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.ToListAsync();
            var hinhAnhQuangCao = await _dataContext.HinhAnhQuangCao.ToListAsync();

            var viewModel = new SanPhamChiTietViewModel
            {
                SanPhamList = sanPhamList,
                HinhAnhList = hinhAnhList,
                HinhAnhQuangCao = hinhAnhQuangCao
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Details(int maSanPham)
        {
            var sanPham = await _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
            var danhSachLoaiSanPham = await _dataContext.SANPHAM.Where(x => x.MaLoaiSanPham == sanPham.MaLoaiSanPham).ToListAsync();
            var hinhAnhList = await _dataContext.HINHANH.Where(x => x.MaSanPham == sanPham.MaSanPham).ToListAsync();

            // key
            var maThuongHieu = await _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).Select(m => m.MaThuongHieu).FirstOrDefaultAsync();

            var maBoNho = await _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).Select(m => m.MaBoNho).FirstOrDefaultAsync();

            var maMauSac = await _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).Select(m => m.MaMauSac).FirstOrDefaultAsync();

            var maRam = await _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).Select(m => m.MaRam).FirstOrDefaultAsync();
            // object
            var thuongHieu = await _dataContext.THUONGHIEU.Where(x => x.MaThuongHieu == maThuongHieu).FirstOrDefaultAsync();

            var boNho = await _dataContext.BONHO.Where(x => x.MaBoNho == maBoNho).FirstOrDefaultAsync();

            var mauSac = await _dataContext.MAUSAC.Where(x => x.MaMauSac == maMauSac).FirstOrDefaultAsync();

            var ram = await _dataContext.RAM.Where(x => x.MaRam == maRam).FirstOrDefaultAsync();

            var viewModel = new SanPhamChiTietViewModel();
            if (sanPham is Iphone)
            {
                Iphone product = await _dataContext.IPHONE.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
                viewModel = new SanPhamChiTietViewModel
                {
                    Iphone = product,
                };
            } 
            else if (sanPham is Laptop)
            {
                Laptop lap = await _dataContext.LAPTOP.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
                viewModel = new SanPhamChiTietViewModel
                {
                    Laptop = lap,
                };
            }
            else if (sanPham is IMac)
            {
                IMac imac = await _dataContext.IMAC.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
                viewModel = new SanPhamChiTietViewModel
                {
                    Imac = imac,
                };
            } 
            else if (sanPham is Ipad)
            {
                Ipad ipadPr =  await _dataContext.IPAD.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
                viewModel = new SanPhamChiTietViewModel
                {
                    Ipad = ipadPr,
                };
            }
            
            viewModel.SanPhamList = danhSachLoaiSanPham;
            viewModel.HinhAnhList = hinhAnhList;
            viewModel.SanPham = sanPham;

            viewModel.MauSac = mauSac;

            viewModel.Ram = ram;
            viewModel.ThuongHieu = thuongHieu;
            viewModel.BoNho = boNho;
            viewModel.context = _dataContext;

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
                IphoneList = iphone,
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
                IpadList = ipad,
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
                IMacList = imac,
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
                LaptopList = laptop,
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

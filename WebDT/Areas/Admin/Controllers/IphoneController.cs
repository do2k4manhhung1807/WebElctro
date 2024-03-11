using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDT.Data;
using WebDT.Models;
using WebDT.ViewModel;

namespace WebDT.Areas.Admin.Controllers
{
    /*    [Authorize]
    */
    [Area("Admin")]
    public class IphoneController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public IphoneController(ApplicationDbContext context, IWebHostEnvironment webHost )
        {
            _context = context;
            _webHost = webHost;

        }


        public async Task<IActionResult> Index()
        {
            var iphone = await _context.IPHONE.ToListAsync();
            return View(iphone);

        }
        public async Task<IActionResult> Create()
        {
            ViewBag.BoNho = new SelectList(_context.BONHO, "MaBoNho", "DungLuongBoNho");
            ViewBag.MauSac = new SelectList(_context.MAUSAC, "MaMauSac", "TenMau");
            ViewBag.Ram = new SelectList(_context.RAM, "MaRam", "TenRam");
            ViewBag.LoaiSanPham = new SelectList(_context.LOAISANPHAM, "MaLoaiSanPham", "TenLoaiSanPham");
            ViewBag.ThuongHieu = new SelectList(_context.THUONGHIEU, "MaThuongHieu", "TenThuongHieu");
            IphoneViewModel iphone = new IphoneViewModel();
            return View(iphone);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IphoneViewModel iphone)
        {
            if (iphone == null || iphone.Phone == null)
            {
                return View(iphone);
            }

            /*Add data for iphone*/
            Iphone dienThoai = new Iphone()
            {
                TenSanPham = iphone.Phone.TenSanPham,
                Mota = iphone.Phone.Mota,
                Gia = iphone.Phone.Gia,
                ManHinh = iphone.Phone.ManHinh,



                Chip = iphone.Phone.Chip,
                MaThuongHieu = iphone.MaThuongHieu,
                MaLoaiSanPham = iphone.MaLoaiSanPham,

                Rom = iphone.Phone.Rom,
                CameraTruoc = iphone.Phone.CameraTruoc,
                CameraSau = iphone.Phone.CameraSau,
                Pin = iphone.Phone.Pin
            };
            await _context.SANPHAM.AddAsync(dienThoai);
            await _context.SaveChangesAsync();
            /*Add data for image table*/
            foreach (var anh in iphone.HinhAnhSanPham)
            {
                string tenAnh = UploadFile(anh);
                HinhAnh hinhAnh = new HinhAnh()
                {
                    FileHinhAnh = tenAnh,
                    MaSanPham = dienThoai.MaSanPham
                };
                await _context.HINHANH.AddAsync(hinhAnh);
            }
            
            /*Add data for dungluong*/
            BoNhoSanPham boNhoSanPham = new BoNhoSanPham() 
            { 
                MaBoNho = iphone.MaBoNho,
                MaSanPham = dienThoai.MaSanPham
            };
            await _context.BONHOSANPHAM.AddAsync(boNhoSanPham);


            /*Add data for ram*/
            RamSanPham ramSanPham = new RamSanPham()
            {
                MaRam = iphone.MaRam,
                MaSanPham = dienThoai.MaSanPham
            };
            await _context.RAMSANPHAM.AddAsync(ramSanPham);


            /*Add data for color*/
            MauSacSanPham mauSacSanPham = new MauSacSanPham() 
            {
                MaMauSac = iphone.MaMauSac,
                MaSanPham = dienThoai.MaSanPham
            };
            await _context.MAUSACSANPHAM.AddAsync(mauSacSanPham);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Iphone");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int maSanPham)
        {
            ViewBag.BoNho = new SelectList(_context.BONHO, "MaBoNho", "DungLuongBoNho");
            ViewBag.MauSac = new SelectList(_context.MAUSAC, "MaMauSac", "TenMau");
            ViewBag.Ram = new SelectList(_context.RAM, "MaRam", "TenRam");
            ViewBag.LoaiSanPham = new SelectList(_context.LOAISANPHAM, "MaLoaiSanPham", "TenLoaiSanPham");
            ViewBag.ThuongHieu = new SelectList(_context.THUONGHIEU, "MaThuongHieu", "TenThuongHieu");

            var dienThoai = await _context.SANPHAM.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
            var phone = await _context.IPHONE.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
            var maRam = await _context.RAMSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                        .Select(m => m.MaRam).FirstOrDefaultAsync();
            var maBoNho = await _context.BONHOSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                    .Select(m => m.MaBoNho).FirstOrDefaultAsync();
            var maMauSac = await _context.MAUSACSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                    .Select(m => m.MaMauSac).FirstOrDefaultAsync();
            var images = await _context.HINHANH.Where(x => x.MaSanPham == maSanPham)
                                .Select(m => m.FileHinhAnh).ToListAsync();
            /*Get key*/
            var boNho = await _context.BONHO.Where(x => x.MaBoNho == maBoNho).Select(t => t.MaBoNho).FirstOrDefaultAsync();
            var mauSac = await _context.MAUSAC.Where(x => x.MaMauSac == maMauSac).Select(t => t.MaMauSac).FirstOrDefaultAsync();
            var ram = await _context.RAM.Where(x => x.MaRam == maRam).Select(t => t.MaRam).FirstOrDefaultAsync();
            

            IphoneViewModel iphone = new IphoneViewModel()
            {
                Phone = phone,
                MaBoNho = boNho,
                MaMauSac = mauSac,
                MaRam = ram,
                MaThuongHieu = phone.MaThuongHieu,
                MaLoaiSanPham = phone.MaLoaiSanPham,
                TenHinhAnh = images
            };
            return View(iphone);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IphoneViewModel iphone)
        {
            Iphone dienThoai = new Iphone()
            {
                MaSanPham = iphone.Phone.MaSanPham,
                TenSanPham = iphone.Phone.TenSanPham,
                Mota = iphone.Phone.Mota,
                Gia = iphone.Phone.Gia,
                ManHinh = iphone.Phone.ManHinh,



                Chip = iphone.Phone.Chip,
                MaThuongHieu = iphone.MaThuongHieu,
                MaLoaiSanPham = iphone.MaLoaiSanPham,

                Rom = iphone.Phone.Rom,
                CameraTruoc = iphone.Phone.CameraTruoc,
                CameraSau = iphone.Phone.CameraSau,
                Pin = iphone.Phone.Pin
            };
            _context.Attach(dienThoai);
            _context.Entry(dienThoai).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            /*Add data for image table*//*
            foreach (var anh in iphone.HinhAnhSanPham)
            {
                string tenAnh = UploadFile(anh);
                var maHinhAnh = _context.HINHANH.Where(x => x.MaSanPham == dienThoai.MaSanPham).Select(m => m.MaHinhAnh).FirstOrDefault();
                HinhAnh hinhAnh = new HinhAnh()
                {
*//*                    MaHinhAnh = maHinhAnh,
*//*                    FileHinhAnh = tenAnh,
                    MaSanPham = dienThoai.MaSanPham
                };
                _context.Attach(hinhAnh);
                _context.Entry(hinhAnh).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }*/


            /*Add data for dungluong*/
            BoNhoSanPham boNhoSanPham = new BoNhoSanPham()
            {
                MaBoNho = iphone.MaBoNho,
                MaSanPham = dienThoai.MaSanPham
            };
            _context.Attach(boNhoSanPham);
            _context.Entry(boNhoSanPham).State = EntityState.Modified;
/*            await _context.SaveChangesAsync();
*/

            /*Add data for ram*/
            RamSanPham ramSanPham = new RamSanPham()
            {
                MaRam = iphone.MaRam,
                MaSanPham = dienThoai.MaSanPham
            };
            _context.Attach(ramSanPham);
            _context.Entry(ramSanPham).State = EntityState.Modified;
/*            await _context.SaveChangesAsync();
*/

            /*Add data for color*/
            MauSacSanPham mauSacSanPham = new MauSacSanPham()
            {
                MaMauSac = iphone.MaMauSac,
                MaSanPham = dienThoai.MaSanPham
            };
            _context.Attach(mauSacSanPham);
            _context.Entry(mauSacSanPham).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Iphone");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int maSanPham)
        {
            var dienThoai = await _context.SANPHAM.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
            var phone = await _context.IPHONE.Where(x => x.MaSanPham == maSanPham).FirstOrDefaultAsync();
            var maRam = await _context.RAMSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                        .Select(m => m.MaRam).FirstOrDefaultAsync();
            var maBoNho = await _context.BONHOSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                    .Select(m => m.MaBoNho).FirstOrDefaultAsync(); 
            var maMauSac = await _context.MAUSACSANPHAM.Where(x => x.MaSanPham == maSanPham)
                                    .Select(m => m.MaMauSac).FirstOrDefaultAsync();
            var images = await _context.HINHANH.Where(x => x.MaSanPham == maSanPham)
                                .Select(m => m.FileHinhAnh).ToListAsync();
            /*Get names*/
            var boNho = await _context.BONHO.Where(x => x.MaBoNho == maBoNho).Select(t => t.DungLuongBoNho).FirstOrDefaultAsync();
            var mauSac = await _context.MAUSAC.Where(x => x.MaMauSac == maMauSac).Select(t => t.TenMau).FirstOrDefaultAsync();
            var ram = await _context.RAM.Where(x => x.MaRam == maRam).Select(t => t.TenRam).FirstOrDefaultAsync();
            var loaiSanPham = await _context.LOAISANPHAM.Where(x => x.MaLoaiSanPham == phone.MaLoaiSanPham).Select(t => t.TenLoaiSanPham).FirstOrDefaultAsync();
            var thuongHieu = await _context.THUONGHIEU.Where(x => x.MaThuongHieu == phone.MaThuongHieu).Select(t => t.TenThuongHieu).FirstOrDefaultAsync();

            IphoneViewModel iphone = new IphoneViewModel() 
            { 
                Phone = phone,
                DungLuongBoNho = boNho,
                TenMauSac = mauSac,
                TenRam = ram,
                TenThuongHieu = thuongHieu,
                TenLoaiSanPham = loaiSanPham,
                TenHinhAnh = images
            };
            return View(iphone);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int maSanPham)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(IphoneViewModel iphone)
        {
            return RedirectToAction("Index", "Iphone");
        }


        private string UploadFile(IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_webHost.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}

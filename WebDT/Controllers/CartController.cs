using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDT.Data;
using WebDT.Models;
using WebDT.Repository;
using WebDT.ViewModel;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace WebDT.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        public CartController(ApplicationDbContext _context)
        {
            _dataContext = _context;
        }

        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>(); // neu co du lieu thi hien thi con khong se tao moi 1 list 
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Soluong* x.Gia),//Tinh tong
                TongSoLuongHienThi = cartItems.Sum(x => x.Soluong),

            };
            return View(cartVM);
        }

        [HttpPost]
        public IActionResult Index(CartItemViewModel donHang)
        {
            if (donHang.DonHang.SoDienThoai == null) 
            {
                return NotFound();
            }


            return RedirectToAction("Iphone","Index");
        }

/*        public async Task<IActionResult> Checkout()
        {
            ViewBag.TrangThaiThanhToan = new SelectList(_dataContext.TrangThaiThanhToan, "MaTrangThaiThanhToan");
            ViewBag.TrangThaiDonHang = new SelectList(_dataContext.TrangThaiDonHang, "MaTrangThaiDonHang");
            CartItemViewModel donHang = new CartItemViewModel();
            return View(donHang);
        }*/
/*        [HttpPost]
        public async Task<IActionResult> Checkout(CartItemViewModel donHang)
        {
            if (donHang == null)
            {
                return View(donHang);
            }

            try
            {
                DonHang donHangList = new DonHang()
                {
                    TenKhachHang = donHang.DonHang.TenKhachHang,
                    SoDienThoai = donHang.DonHang.SoDienThoai,
                    DiaChi = donHang.DonHang.DiaChi,
                    YeuCauKhac = donHang.DonHang.YeuCauKhac,
                    MaTrangThaiDonHang = 5,
                    MaTrangThaiThanhToan = 3,
                    NgayLapDonHang = DateTime.Now,
                };
                await _dataContext.DonHang.AddAsync(donHangList);
                await _dataContext.SaveChangesAsync();

                // Nếu không có lỗi, chuyển hướng về trang chủ
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý ngoại lệ ở đây
                return RedirectToAction("Error", "Home"); // Chuyển hướng đến trang lỗi
            }
        }*/


        public async Task<IActionResult> Add(int maSanPham)
        {
            var sanPham = _dataContext.SANPHAM.Where(x => x.MaSanPham == maSanPham).FirstOrDefault();

            if (sanPham != null)
            {
                var hinhAnhList = await _dataContext.HINHANH
                    .Where(x => x.MaSanPham == sanPham.MaSanPham)
                    .ToListAsync();
                var hinhAnh = hinhAnhList[0].FileHinhAnh;
                var viewModel = new CartItemViewModel();
                List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

                CartItemModel cartItem = cart.FirstOrDefault(c => c.MaSanPham == maSanPham);

                if (cartItem == null)
                {
                    cart.Add(new CartItemModel(sanPham, hinhAnh));
                }
                else
                {
                    cartItem.Soluong += 1;
                }

                HttpContext.Session.SetJson("Cart", cart);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public IActionResult Decrease(int maSanPham)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItem = cart.Where(c => c.MaSanPham == maSanPham).FirstOrDefault();
            if(cartItem.Soluong >1){
                --cartItem.Soluong;
            }
            else
            {
                cart.RemoveAll(p => p.MaSanPham == maSanPham);
            }
            if(cart.Count == 0) {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Increase(int maSanPham)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItem = cart.Where(c => c.MaSanPham == maSanPham).FirstOrDefault();
            if (cartItem.Soluong >= 1)
            {
                ++cartItem.Soluong;
            }
            else
            {
                cart.RemoveAll(p => p.MaSanPham == maSanPham);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int maSanPham)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            cart.RemoveAll(x => x.MaSanPham == maSanPham);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
       

    }
}

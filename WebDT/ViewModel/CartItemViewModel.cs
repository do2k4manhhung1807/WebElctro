using WebDT.Models;

namespace WebDT.ViewModel
{
    public class CartItemViewModel
    {
        public List<CartItemModel> CartItems { get; set; }
        public DonHang DonHang { get; set; } 
/*        public ChiTietDonHangSanPham ChiTietDonHang { get; set; }
*/        
        public decimal GrandTotal { get; set; } //Tinh tong gia
        /*        public int TongSoLuongHienThi => CartItems.Sum(x => x.Soluong);
        */
        public int TongSoLuongHienThi { get; set; } 
    }
}

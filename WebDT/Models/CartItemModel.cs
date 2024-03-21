using System.Drawing;
using System.Net.Http.Headers;
using WebDT.Models;

namespace WebDT.Models
{
    public class CartItemModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; } 
        public int Soluong { get; set; }
        public decimal Gia { get; set; }
        public decimal TongCong { 
            get { return Soluong*Gia; }
        }
        public string HinhAnh { get; set; }
        public CartItemModel() { }//neu khong bam vao gio hang thi gio hang se trong
        public CartItemModel(SanPham sanPham, HinhAnh hinhAnh)
        {
            MaSanPham = sanPham.MaSanPham;
            TenSanPham = sanPham.TenSanPham;
            Gia = sanPham.Gia;
            Soluong = 1;
            HinhAnh = hinhAnh.FileHinhAnh;
        } 
    }
}

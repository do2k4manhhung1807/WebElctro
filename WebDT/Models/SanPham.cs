using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace WebDT.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal Gia { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập thông tin màn hình")]
        public string ManHinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin mô tả")]
        public string Mota { get; set; }
        public int MaThuongHieu { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
        public ICollection<HinhAnh> HinhAnh { get; set; }
        public int MaLoaiSanPham { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public IList<RamSanPham> RamSanPham { get; set; }
        public IList<BoNhoSanPham> BoNhoSanPham { get; set; }
        public IList<MauSacSanPham> MauSacSanPham { get; set; }
    }
}

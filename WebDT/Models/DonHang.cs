﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebDT.Models
{
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }
        public DateTime NgayLapDonHang { get; set; }

        [ForeignKey("TrangThaiThanhToan")]
        public int MaTrangThaiThanhToan { get; set; }
        [ForeignKey("TrangThaiDonHang")]
        public int MaTrangThaiDonHang { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        public string TenKhachHang { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SoDienThoai { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string DiaChi { get; set; }
        public string? YeuCauKhac { get; set; }
        public TrangThaiDonHang TrangThaiDonHang { get; set; }
        public TrangThaiThanhToan TrangThaiThanhToan { get; set; }

        public ICollection<ChiTietDonHangSanPham> ChiTietDonHangSanPham { get; set; }
    }
}

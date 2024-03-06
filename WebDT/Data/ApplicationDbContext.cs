using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using WebDT.Models;

namespace WebDT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<SanPham> BONHO { get; set; }
        public DbSet<BoNhoSanPham> BONHOSANPHAM { get; set; }
        public DbSet<HinhAnh> HINHANH { get; set; }
        public DbSet<IMac> IMAC { get; set; }
        public DbSet<Ipad> IPAD { get; set; }
        public DbSet<Iphone> IPHONE { get; set; }
        public DbSet<Laptop> LAPTOP { get; set; }
        public DbSet<LoaiSanPham> LOAISANPHAM { get; set; }
        public DbSet<MauSac> MAUSAC { get; set; }
        public DbSet<MauSacSanPham> MAUSACSANPHAM { get; set; }
        public DbSet<Ram> RAM { get; set; }
        public DbSet<RamSanPham> RAMSANPHAM { get; set; }
        public DbSet<ThuongHieu> THUONGHIEU { get; set; }
        public DbSet<SanPham> SANPHAM { get; set; }
        public virtual DbSet<TrangThaiDonHang> TrangThaiDonHang { get; set; }
        public virtual DbSet<TrangThaiThanhToan> TrangThaiThanhToan { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<ChiTietDonHangSanPham> ChiTietDonHangSanPham { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HinhAnh>()
                .HasOne<SanPham>(s => s.SanPham)
                .WithMany(g => g.HinhAnh)
                .HasForeignKey(s => s.MaSanPham);

            modelBuilder.Entity<SanPham>()
               .HasOne<LoaiSanPham>(l => l.LoaiSanPham)
               .WithMany(s => s.SanPham)
               .HasForeignKey(s => s.MaLoaiSanPham);

            modelBuilder.Entity<SanPham>()
              .HasOne<ThuongHieu>(t => t.ThuongHieu)
              .WithMany(s => s.SanPham)
              .HasForeignKey(s => s.MaThuongHieu);

            modelBuilder.Entity<BoNhoSanPham>().HasKey(sc => new { sc.MaSanPham, sc.MaBoNho });

            modelBuilder.Entity<BoNhoSanPham>()
                .HasOne<SanPham>(sp => sp.SanPham)
                .WithMany(bn => bn.BoNhoSanPham)
                .HasForeignKey(m => m.MaSanPham);


            modelBuilder.Entity<BoNhoSanPham>()
                .HasOne<BoNho>(b => b.BoNho)
                .WithMany(bn => bn.BoNhoSanPham)
                .HasForeignKey(sc => sc.MaBoNho);

            modelBuilder.Entity<MauSacSanPham>().HasKey(sc => new { sc.MaSanPham, sc.MaMauSac});

            modelBuilder.Entity<MauSacSanPham>()
                .HasOne<SanPham>(sp => sp.SanPham)
                .WithMany(ms => ms.MauSacSanPham)
                .HasForeignKey(m => m.MaSanPham);


            modelBuilder.Entity<MauSacSanPham>()
                .HasOne<MauSac>(b => b.MauSac)
                .WithMany(ms => ms.MauSacSanPham)
                .HasForeignKey(m => m.MaMauSac);

            modelBuilder.Entity<RamSanPham>().HasKey(sc => new { sc.MaSanPham, sc.MaRam });

            modelBuilder.Entity<RamSanPham>()
                .HasOne<SanPham>(sp => sp.SanPham)
                .WithMany(ms => ms.RamSanPham)
                .HasForeignKey(m => m.MaSanPham);


            modelBuilder.Entity<RamSanPham>()
                .HasOne<Ram>(b => b.Ram)
                .WithMany(ms => ms.RamSanPham)
                .HasForeignKey(m => m.MaRam);

            modelBuilder.Entity<ChiTietDonHangSanPham>().HasKey(sc => new { sc.MaSanPham, sc.MaDonHang });

            modelBuilder.Entity<ChiTietDonHangSanPham>()
                .HasOne(sc => sc.SanPham)
                .WithMany(s => s.ChiTietDonHangSanPham)
                .HasForeignKey(sc => sc.MaSanPham);

            modelBuilder.Entity<ChiTietDonHangSanPham>()
                .HasOne(sc => sc.DonHang)
                .WithMany(s => s.ChiTietDonHangSanPham)
                .HasForeignKey(sc => sc.MaDonHang);

            modelBuilder.Entity<SanPham>()
           .ToTable("SanPham")
           .HasDiscriminator<int>("SanPham")
           .HasValue<Iphone>(1)
           .HasValue<Ipad>(2)
           .HasValue<IMac>(3)
           .HasValue<Laptop>(4)
           .HasValue<SanPham>(0);
        }
        public DbSet<WebDT.Models.BoNho> BoNho { get; set; } = default!;
    }
}

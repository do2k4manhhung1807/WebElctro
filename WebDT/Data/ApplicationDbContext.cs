﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using WebDT.Models;
using WebDT.ViewModel;

namespace WebDT.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BoNho> BONHO { get; set; }
        public DbSet<HinhAnh> HINHANH { get; set; }
        public DbSet<IMac> IMAC { get; set; }
        public DbSet<Ipad> IPAD { get; set; }
        public DbSet<Iphone> IPHONE { get; set; }
        public DbSet<Laptop> LAPTOP { get; set; }
        public DbSet<LoaiSanPham> LOAISANPHAM { get; set; }
        public DbSet<MauSac> MAUSAC { get; set; }
        public DbSet<Ram> RAM { get; set; }
        public DbSet<ThuongHieu> THUONGHIEU { get; set; }
        public DbSet<SanPham> SANPHAM { get; set; }
        public DbSet<TrangThaiDonHang> TrangThaiDonHang { get; set; }
        public DbSet<TrangThaiThanhToan> TrangThaiThanhToan { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<ChiTietDonHangSanPham> ChiTietDonHangSanPham { get; set; }
        public DbSet<SanPhamDacBiet> SanPhamDacBiet { get; set; }
        public DbSet<HinhAnhQuangCao> HinhAnhQuangCao { get; set; }

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

            modelBuilder.Entity<SanPham>()
                .HasOne<MauSac>(m => m.MauSac)
                .WithMany(s => s.SanPham)
                .HasForeignKey(s => s.MaMauSac);

            modelBuilder.Entity<SanPham>()
                .HasOne<BoNho>(m => m.BoNho)
                .WithMany(s => s.SanPham)
                .HasForeignKey(s => s.MaBoNho);

            modelBuilder.Entity<SanPham>()
                .HasOne<Ram>(m => m.Ram)
                .WithMany(s => s.SanPham)
                .HasForeignKey(s => s.MaRam);

            modelBuilder.Entity<SanPham>()
               .HasOne<SanPhamDacBiet>(l => l.SanPhamDacBiet)
               .WithMany(s => s.SanPham)
               .HasForeignKey(s => s.MaSanPhamDacBiet);

            modelBuilder.Entity<ChiTietDonHangSanPham>()
                .HasKey(sc => new { sc.MaSanPham, sc.MaDonHang });

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


                    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
        }


}
    }
}

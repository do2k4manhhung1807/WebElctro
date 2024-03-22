﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebDT.Data;

#nullable disable

namespace WebDT.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240317151117_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebDT.Models.BoNho", b =>
                {
                    b.Property<int>("MaBoNho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBoNho"));

                    b.Property<string>("DungLuongBoNho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaBoNho");

                    b.ToTable("BONHO");
                });

            modelBuilder.Entity("WebDT.Models.ChiTietDonHangSanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int>("SoluongMua")
                        .HasColumnType("int");

                    b.HasKey("MaSanPham", "MaDonHang");

                    b.HasIndex("MaDonHang");

                    b.ToTable("ChiTietDonHangSanPham");
                });

            modelBuilder.Entity("WebDT.Models.DonHang", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaTrangThaiDonHang")
                        .HasColumnType("int");

                    b.Property<int>("MaTrangThaiThanhToan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayLapDonHang")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YeuCauKhac")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaTrangThaiDonHang");

                    b.HasIndex("MaTrangThaiThanhToan");

                    b.ToTable("DonHang");
                });

            modelBuilder.Entity("WebDT.Models.HinhAnh", b =>
                {
                    b.Property<int>("MaHinhAnh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHinhAnh"));

                    b.Property<string>("FileHinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.HasKey("MaHinhAnh");

                    b.HasIndex("MaSanPham");

                    b.ToTable("HINHANH");
                });

            modelBuilder.Entity("WebDT.Models.HinhAnhQuangCao", b =>
                {
                    b.Property<int>("MaAnhQuangCao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaAnhQuangCao"));

                    b.Property<string>("FileAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaAnhQuangCao");

                    b.ToTable("HinhAnhQuangCao");
                });

            modelBuilder.Entity("WebDT.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("MaLoaiSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiSanPham"));

                    b.Property<string>("TenLoaiSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiSanPham");

                    b.ToTable("LOAISANPHAM");
                });

            modelBuilder.Entity("WebDT.Models.MauSac", b =>
                {
                    b.Property<int>("MaMauSac")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaMauSac"));

                    b.Property<string>("TenMau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaMauSac");

                    b.ToTable("MAUSAC");
                });

            modelBuilder.Entity("WebDT.Models.Ram", b =>
                {
                    b.Property<int>("MaRam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaRam"));

                    b.Property<string>("TenRam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaRam");

                    b.ToTable("RAM");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaBoNho")
                        .HasColumnType("int");

                    b.Property<int>("MaLoaiSanPham")
                        .HasColumnType("int");

                    b.Property<int>("MaMauSac")
                        .HasColumnType("int");

                    b.Property<int>("MaRam")
                        .HasColumnType("int");

                    b.Property<int>("MaSanPhamDacBiet")
                        .HasColumnType("int");

                    b.Property<int>("MaThuongHieu")
                        .HasColumnType("int");

                    b.Property<string>("ManHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPham")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaBoNho");

                    b.HasIndex("MaLoaiSanPham");

                    b.HasIndex("MaMauSac");

                    b.HasIndex("MaRam");

                    b.HasIndex("MaSanPhamDacBiet");

                    b.HasIndex("MaThuongHieu");

                    b.ToTable("SanPham", (string)null);

                    b.HasDiscriminator<int>("SanPham").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("WebDT.Models.SanPhamDacBiet", b =>
                {
                    b.Property<int>("MaSanPhamDacBiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPhamDacBiet"));

                    b.Property<string>("LoaiSanPhamDacBiet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSanPhamDacBiet");

                    b.ToTable("SanPhamDacBiet");
                });

            modelBuilder.Entity("WebDT.Models.ThuongHieu", b =>
                {
                    b.Property<int>("MaThuongHieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThuongHieu"));

                    b.Property<string>("TenThuongHieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaThuongHieu");

                    b.ToTable("THUONGHIEU");
                });

            modelBuilder.Entity("WebDT.Models.TrangThaiDonHang", b =>
                {
                    b.Property<int>("MaTrangThaiDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrangThaiDonHang"));

                    b.Property<string>("TenTrangThaiDonHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTrangThaiDonHang");

                    b.ToTable("TrangThaiDonHang");
                });

            modelBuilder.Entity("WebDT.Models.TrangThaiThanhToan", b =>
                {
                    b.Property<int>("MaTrangThaiDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTrangThaiDonHang"));

                    b.Property<string>("TenTrangThaiDonHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTrangThaiDonHang");

                    b.ToTable("TrangThaiThanhToan");
                });

            modelBuilder.Entity("WebDT.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebDT.Models.IMac", b =>
                {
                    b.HasBaseType("WebDT.Models.SanPham");

                    b.Property<string>("CongNgheCPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TocDoCPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turbo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("WebDT.Models.Ipad", b =>
                {
                    b.HasBaseType("WebDT.Models.SanPham");

                    b.Property<string>("CongNgheManHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoPhanGiai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KichThuocVatLy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("WebDT.Models.Iphone", b =>
                {
                    b.HasBaseType("WebDT.Models.SanPham");

                    b.Property<string>("CameraSau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraTruoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("WebDT.Models.Laptop", b =>
                {
                    b.HasBaseType("WebDT.Models.SanPham");

                    b.Property<string>("CPU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoNhanLuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrongLuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VGA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebDT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebDT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebDT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebDT.Models.ChiTietDonHangSanPham", b =>
                {
                    b.HasOne("WebDT.Models.DonHang", "DonHang")
                        .WithMany("ChiTietDonHangSanPham")
                        .HasForeignKey("MaDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.SanPham", "SanPham")
                        .WithMany("ChiTietDonHangSanPham")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.DonHang", b =>
                {
                    b.HasOne("WebDT.Models.TrangThaiDonHang", "TrangThaiDonHang")
                        .WithMany("DonHang")
                        .HasForeignKey("MaTrangThaiDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.TrangThaiThanhToan", "TrangThaiThanhToan")
                        .WithMany("DonHang")
                        .HasForeignKey("MaTrangThaiThanhToan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrangThaiDonHang");

                    b.Navigation("TrangThaiThanhToan");
                });

            modelBuilder.Entity("WebDT.Models.HinhAnh", b =>
                {
                    b.HasOne("WebDT.Models.SanPham", "SanPham")
                        .WithMany("HinhAnh")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.HasOne("WebDT.Models.BoNho", "BoNho")
                        .WithMany("SanPham")
                        .HasForeignKey("MaBoNho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPham")
                        .HasForeignKey("MaLoaiSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.MauSac", "MauSac")
                        .WithMany("SanPham")
                        .HasForeignKey("MaMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.Ram", "Ram")
                        .WithMany("SanPham")
                        .HasForeignKey("MaRam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.SanPhamDacBiet", "SanPhamDacBiet")
                        .WithMany("SanPham")
                        .HasForeignKey("MaSanPhamDacBiet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.ThuongHieu", "ThuongHieu")
                        .WithMany("SanPham")
                        .HasForeignKey("MaThuongHieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoNho");

                    b.Navigation("LoaiSanPham");

                    b.Navigation("MauSac");

                    b.Navigation("Ram");

                    b.Navigation("SanPhamDacBiet");

                    b.Navigation("ThuongHieu");
                });

            modelBuilder.Entity("WebDT.Models.BoNho", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.DonHang", b =>
                {
                    b.Navigation("ChiTietDonHangSanPham");
                });

            modelBuilder.Entity("WebDT.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.MauSac", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.Ram", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.Navigation("ChiTietDonHangSanPham");

                    b.Navigation("HinhAnh");
                });

            modelBuilder.Entity("WebDT.Models.SanPhamDacBiet", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.ThuongHieu", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.TrangThaiDonHang", b =>
                {
                    b.Navigation("DonHang");
                });

            modelBuilder.Entity("WebDT.Models.TrangThaiThanhToan", b =>
                {
                    b.Navigation("DonHang");
                });
#pragma warning restore 612, 618
        }
    }
}
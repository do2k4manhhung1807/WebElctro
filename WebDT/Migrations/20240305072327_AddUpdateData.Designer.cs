﻿// <auto-generated />
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
    [Migration("20240305072327_AddUpdateData")]
    partial class AddUpdateData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.ToTable("BoNho");
                });

            modelBuilder.Entity("WebDT.Models.BoNhoSanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("MaBoNho")
                        .HasColumnType("int");

                    b.HasKey("MaSanPham", "MaBoNho");

                    b.HasIndex("MaBoNho");

                    b.ToTable("BONHOSANPHAM");
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

            modelBuilder.Entity("WebDT.Models.MauSacSanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("MaMauSac")
                        .HasColumnType("int");

                    b.HasKey("MaSanPham", "MaMauSac");

                    b.HasIndex("MaMauSac");

                    b.ToTable("MAUSACSANPHAM");
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

            modelBuilder.Entity("WebDT.Models.RamSanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .HasColumnType("int");

                    b.Property<int>("MaRam")
                        .HasColumnType("int");

                    b.HasKey("MaSanPham", "MaRam");

                    b.HasIndex("MaRam");

                    b.ToTable("RAMSANPHAM");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.Property<int>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSanPham"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaLoaiSanPham")
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

                    b.HasIndex("MaLoaiSanPham");

                    b.HasIndex("MaThuongHieu");

                    b.ToTable("SanPham", (string)null);

                    b.HasDiscriminator<int>("SanPham").HasValue(0);

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("WebDT.Models.BoNhoSanPham", b =>
                {
                    b.HasOne("WebDT.Models.BoNho", "BoNho")
                        .WithMany("BoNhoSanPham")
                        .HasForeignKey("MaBoNho")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.SanPham", "SanPham")
                        .WithMany("BoNhoSanPham")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoNho");

                    b.Navigation("SanPham");
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

            modelBuilder.Entity("WebDT.Models.MauSacSanPham", b =>
                {
                    b.HasOne("WebDT.Models.MauSac", "MauSac")
                        .WithMany("MauSacSanPham")
                        .HasForeignKey("MaMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.SanPham", "SanPham")
                        .WithMany("MauSacSanPham")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.RamSanPham", b =>
                {
                    b.HasOne("WebDT.Models.Ram", "Ram")
                        .WithMany("RamSanPham")
                        .HasForeignKey("MaRam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.SanPham", "SanPham")
                        .WithMany("RamSanPham")
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ram");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.HasOne("WebDT.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPham")
                        .HasForeignKey("MaLoaiSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebDT.Models.ThuongHieu", "ThuongHieu")
                        .WithMany("SanPham")
                        .HasForeignKey("MaThuongHieu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");

                    b.Navigation("ThuongHieu");
                });

            modelBuilder.Entity("WebDT.Models.BoNho", b =>
                {
                    b.Navigation("BoNhoSanPham");
                });

            modelBuilder.Entity("WebDT.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("WebDT.Models.MauSac", b =>
                {
                    b.Navigation("MauSacSanPham");
                });

            modelBuilder.Entity("WebDT.Models.Ram", b =>
                {
                    b.Navigation("RamSanPham");
                });

            modelBuilder.Entity("WebDT.Models.SanPham", b =>
                {
                    b.Navigation("BoNhoSanPham");

                    b.Navigation("HinhAnh");

                    b.Navigation("MauSacSanPham");

                    b.Navigation("RamSanPham");
                });

            modelBuilder.Entity("WebDT.Models.ThuongHieu", b =>
                {
                    b.Navigation("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}

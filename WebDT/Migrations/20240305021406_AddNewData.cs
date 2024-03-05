using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDT.Migrations
{
    /// <inheritdoc />
    public partial class AddNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoNho",
                columns: table => new
                {
                    MaBoNho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DungLuongBoNho = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoNho", x => x.MaBoNho);
                });

            migrationBuilder.CreateTable(
                name: "LOAISANPHAM",
                columns: table => new
                {
                    MaLoaiSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAISANPHAM", x => x.MaLoaiSanPham);
                });

            migrationBuilder.CreateTable(
                name: "MAUSAC",
                columns: table => new
                {
                    MaMauSac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUSAC", x => x.MaMauSac);
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    MaRam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenRam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.MaRam);
                });

            migrationBuilder.CreateTable(
                name: "THUONGHIEU",
                columns: table => new
                {
                    MaThuongHieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUONGHIEU", x => x.MaThuongHieu);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManHinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaThuongHieu = table.Column<int>(type: "int", nullable: false),
                    MaLoaiSanPham = table.Column<int>(type: "int", nullable: false),
                    SanPham = table.Column<int>(type: "int", nullable: false),
                    CongNgheCPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TocDoCPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Turbo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CongNgheManHinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KichThuocVatLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraTruoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraSau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoNhanLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrongLuong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_LOAISANPHAM_MaLoaiSanPham",
                        column: x => x.MaLoaiSanPham,
                        principalTable: "LOAISANPHAM",
                        principalColumn: "MaLoaiSanPham",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPham_THUONGHIEU_MaThuongHieu",
                        column: x => x.MaThuongHieu,
                        principalTable: "THUONGHIEU",
                        principalColumn: "MaThuongHieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BONHOSANPHAM",
                columns: table => new
                {
                    MaBoNho = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BONHOSANPHAM", x => new { x.MaSanPham, x.MaBoNho });
                    table.ForeignKey(
                        name: "FK_BONHOSANPHAM_BoNho_MaBoNho",
                        column: x => x.MaBoNho,
                        principalTable: "BoNho",
                        principalColumn: "MaBoNho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BONHOSANPHAM_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HINHANH",
                columns: table => new
                {
                    MaHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINHANH", x => x.MaHinhAnh);
                    table.ForeignKey(
                        name: "FK_HINHANH_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MAUSACSANPHAM",
                columns: table => new
                {
                    MaMauSac = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUSACSANPHAM", x => new { x.MaSanPham, x.MaMauSac });
                    table.ForeignKey(
                        name: "FK_MAUSACSANPHAM_MAUSAC_MaMauSac",
                        column: x => x.MaMauSac,
                        principalTable: "MAUSAC",
                        principalColumn: "MaMauSac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MAUSACSANPHAM_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAMSANPHAM",
                columns: table => new
                {
                    MaRam = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMSANPHAM", x => new { x.MaSanPham, x.MaRam });
                    table.ForeignKey(
                        name: "FK_RAMSANPHAM_RAM_MaRam",
                        column: x => x.MaRam,
                        principalTable: "RAM",
                        principalColumn: "MaRam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RAMSANPHAM_SanPham_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BONHOSANPHAM_MaBoNho",
                table: "BONHOSANPHAM",
                column: "MaBoNho");

            migrationBuilder.CreateIndex(
                name: "IX_HINHANH_MaSanPham",
                table: "HINHANH",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_MAUSACSANPHAM_MaMauSac",
                table: "MAUSACSANPHAM",
                column: "MaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_RAMSANPHAM_MaRam",
                table: "RAMSANPHAM",
                column: "MaRam");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaLoaiSanPham",
                table: "SanPham",
                column: "MaLoaiSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaThuongHieu",
                table: "SanPham",
                column: "MaThuongHieu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BONHOSANPHAM");

            migrationBuilder.DropTable(
                name: "HINHANH");

            migrationBuilder.DropTable(
                name: "MAUSACSANPHAM");

            migrationBuilder.DropTable(
                name: "RAMSANPHAM");

            migrationBuilder.DropTable(
                name: "BoNho");

            migrationBuilder.DropTable(
                name: "MAUSAC");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "LOAISANPHAM");

            migrationBuilder.DropTable(
                name: "THUONGHIEU");
        }
    }
}

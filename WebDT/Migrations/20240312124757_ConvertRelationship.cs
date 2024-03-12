using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDT.Migrations
{
    /// <inheritdoc />
    public partial class ConvertRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MAUSACSANPHAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MAUSAC",
                table: "MAUSAC");

            migrationBuilder.RenameTable(
                name: "MAUSAC",
                newName: "MauSac");

            migrationBuilder.AddColumn<int>(
                name: "MaMauSac",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac",
                column: "MaMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaMauSac",
                table: "SanPham",
                column: "MaMauSac");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MauSac_MaMauSac",
                table: "SanPham",
                column: "MaMauSac",
                principalTable: "MauSac",
                principalColumn: "MaMauSac",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MauSac_MaMauSac",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaMauSac",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac");

            migrationBuilder.DropColumn(
                name: "MaMauSac",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "MauSac",
                newName: "MAUSAC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MAUSAC",
                table: "MAUSAC",
                column: "MaMauSac");

            migrationBuilder.CreateTable(
                name: "MAUSACSANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    MaMauSac = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_MAUSACSANPHAM_MaMauSac",
                table: "MAUSACSANPHAM",
                column: "MaMauSac");
        }
    }
}

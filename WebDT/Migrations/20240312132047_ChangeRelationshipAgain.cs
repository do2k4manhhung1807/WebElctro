using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDT.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BONHOSANPHAM");

            migrationBuilder.DropTable(
                name: "RAMSANPHAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RAM",
                table: "RAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BONHO",
                table: "BONHO");

            migrationBuilder.RenameTable(
                name: "RAM",
                newName: "Ram");

            migrationBuilder.RenameTable(
                name: "BONHO",
                newName: "BoNho");

            migrationBuilder.AddColumn<int>(
                name: "MaBoNho",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaRam",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ram",
                table: "Ram",
                column: "MaRam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoNho",
                table: "BoNho",
                column: "MaBoNho");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaBoNho",
                table: "SanPham",
                column: "MaBoNho");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaRam",
                table: "SanPham",
                column: "MaRam");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoNho_MaBoNho",
                table: "SanPham",
                column: "MaBoNho",
                principalTable: "BoNho",
                principalColumn: "MaBoNho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Ram_MaRam",
                table: "SanPham",
                column: "MaRam",
                principalTable: "Ram",
                principalColumn: "MaRam",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoNho_MaBoNho",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Ram_MaRam",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaBoNho",
                table: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaRam",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ram",
                table: "Ram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoNho",
                table: "BoNho");

            migrationBuilder.DropColumn(
                name: "MaBoNho",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "MaRam",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "Ram",
                newName: "RAM");

            migrationBuilder.RenameTable(
                name: "BoNho",
                newName: "BONHO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RAM",
                table: "RAM",
                column: "MaRam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BONHO",
                table: "BONHO",
                column: "MaBoNho");

            migrationBuilder.CreateTable(
                name: "BONHOSANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    MaBoNho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BONHOSANPHAM", x => new { x.MaSanPham, x.MaBoNho });
                    table.ForeignKey(
                        name: "FK_BONHOSANPHAM_BONHO_MaBoNho",
                        column: x => x.MaBoNho,
                        principalTable: "BONHO",
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
                name: "RAMSANPHAM",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    MaRam = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_RAMSANPHAM_MaRam",
                table: "RAMSANPHAM",
                column: "MaRam");
        }
    }
}

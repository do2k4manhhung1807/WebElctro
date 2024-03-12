using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDT.Migrations
{
    /// <inheritdoc />
    public partial class SanPhamDacBietTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaSanPhamDacBiet",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);



        
            migrationBuilder.CreateTable(
                name: "SanPhamDacBiet",
                columns: table => new
                {
                    MaSanPhamDacBiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiSanPhamDacBiet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDacBiet", x => x.MaSanPhamDacBiet);
                });




         

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaSanPhamDacBiet",
                table: "SanPham",
                column: "MaSanPhamDacBiet");

          

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BONHOSANPHAM_BONHO_MaBoNho",
                table: "BONHOSANPHAM");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_SanPhamDacBiet_MaSanPhamDacBiet",
                table: "SanPham");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SanPhamDacBiet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_SanPham_MaSanPhamDacBiet",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BONHO",
                table: "BONHO");

            migrationBuilder.DropColumn(
                name: "MaSanPhamDacBiet",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "BONHO",
                newName: "BoNho");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoNho",
                table: "BoNho",
                column: "MaBoNho");

            migrationBuilder.AddForeignKey(
                name: "FK_BONHOSANPHAM_BoNho_MaBoNho",
                table: "BONHOSANPHAM",
                column: "MaBoNho",
                principalTable: "BoNho",
                principalColumn: "MaBoNho",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

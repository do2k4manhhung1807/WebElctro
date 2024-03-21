using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDT.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BoNho_MaBoNho",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MauSac_MaMauSac",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_Ram_MaRam",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ram",
                table: "Ram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoNho",
                table: "BoNho");

            migrationBuilder.RenameTable(
                name: "Ram",
                newName: "RAM");

            migrationBuilder.RenameTable(
                name: "MauSac",
                newName: "MAUSAC");

            migrationBuilder.RenameTable(
                name: "BoNho",
                newName: "BONHO");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RAM",
                table: "RAM",
                column: "MaRam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MAUSAC",
                table: "MAUSAC",
                column: "MaMauSac");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BONHO",
                table: "BONHO",
                column: "MaBoNho");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BONHO_MaBoNho",
                table: "SanPham",
                column: "MaBoNho",
                principalTable: "BONHO",
                principalColumn: "MaBoNho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MAUSAC_MaMauSac",
                table: "SanPham",
                column: "MaMauSac",
                principalTable: "MAUSAC",
                principalColumn: "MaMauSac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_RAM_MaRam",
                table: "SanPham",
                column: "MaRam",
                principalTable: "RAM",
                principalColumn: "MaRam",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_BONHO_MaBoNho",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_MAUSAC_MaMauSac",
                table: "SanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPham_RAM_MaRam",
                table: "SanPham");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RAM",
                table: "RAM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MAUSAC",
                table: "MAUSAC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BONHO",
                table: "BONHO");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "RAM",
                newName: "Ram");

            migrationBuilder.RenameTable(
                name: "MAUSAC",
                newName: "MauSac");

            migrationBuilder.RenameTable(
                name: "BONHO",
                newName: "BoNho");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ram",
                table: "Ram",
                column: "MaRam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac",
                column: "MaMauSac");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoNho",
                table: "BoNho",
                column: "MaBoNho");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_BoNho_MaBoNho",
                table: "SanPham",
                column: "MaBoNho",
                principalTable: "BoNho",
                principalColumn: "MaBoNho",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_MauSac_MaMauSac",
                table: "SanPham",
                column: "MaMauSac",
                principalTable: "MauSac",
                principalColumn: "MaMauSac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPham_Ram_MaRam",
                table: "SanPham",
                column: "MaRam",
                principalTable: "Ram",
                principalColumn: "MaRam",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

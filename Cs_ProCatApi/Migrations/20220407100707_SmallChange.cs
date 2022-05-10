using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_ProCatApi.Migrations
{
    public partial class SmallChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatogeryRowId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CatogeryRowId",
                table: "Products",
                newName: "CategoryRowId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CatogeryRowId",
                table: "Products",
                newName: "IX_Products_CategoryRowId");

            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "ErrorLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryRowId",
                table: "Products",
                column: "CategoryRowId",
                principalTable: "Categories",
                principalColumn: "CategoryRowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryRowId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryRowId",
                table: "Products",
                newName: "CatogeryRowId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryRowId",
                table: "Products",
                newName: "IX_Products_CatogeryRowId");

            migrationBuilder.AlterColumn<string>(
                name: "StackTrace",
                table: "ErrorLogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatogeryRowId",
                table: "Products",
                column: "CatogeryRowId",
                principalTable: "Categories",
                principalColumn: "CategoryRowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

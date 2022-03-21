using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cs_EFcore_CodeFirst.Migrations
{
    public partial class addcolumnmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DegreeType",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeType",
                table: "Course");
        }
    }
}

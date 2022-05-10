using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Bahubali.Migrations.ScoresDb
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MathsScore = table.Column<int>(type: "int", nullable: false),
                    ScienceScore = table.Column<int>(type: "int", nullable: false),
                    GeographyScore = table.Column<int>(type: "int", nullable: false),
                    HistoryScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsA.Migrations
{
    public partial class SecondChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Efekty",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ocena = table.Column<string>(nullable: true),
                    Good_Answers = table.Column<int>(nullable: false),
                    NumberOf = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efekty", x => x.GradeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Efekty");
        }
    }
}

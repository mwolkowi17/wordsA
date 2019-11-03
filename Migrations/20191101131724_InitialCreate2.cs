using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsA.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slownik",
                columns: table => new
                {
                    TabelaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordEng = table.Column<string>(nullable: true),
                    WordPol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slownik", x => x.TabelaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slownik");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FonAnalizi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesSaves",
                columns: table => new
                {
                    SaveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesSaves", x => x.SaveId);
                });

            migrationBuilder.CreateTable(
                name: "Fons",
                columns: table => new
                {
                    FonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FonName = table.Column<string>(type: "TEXT", nullable: true),
                    FonShort = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    OneDayChange = table.Column<double>(type: "REAL", nullable: true),
                    OneWeekChange = table.Column<double>(type: "REAL", nullable: true),
                    OneMonthChange = table.Column<double>(type: "REAL", nullable: true),
                    ThreeMonthChange = table.Column<double>(type: "REAL", nullable: true),
                    SixMonthChange = table.Column<double>(type: "REAL", nullable: true),
                    OneYearChange = table.Column<double>(type: "REAL", nullable: true),
                    ThreeYearChange = table.Column<double>(type: "REAL", nullable: true),
                    FiveYearChange = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fons", x => x.FonId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoriesSaves");

            migrationBuilder.DropTable(
                name: "Fons");
        }
    }
}

using System;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ApplicableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeatherStateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeatherStateAbbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeed = table.Column<float>(type: "real", nullable: false),
                    WindDirection = table.Column<float>(type: "real", nullable: false),
                    AirPressure = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
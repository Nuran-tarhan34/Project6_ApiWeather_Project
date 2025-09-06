using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project6_ApiWeather.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tempruter",
                table: "Cities",
                newName: "Tempruter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tempruter",
                table: "Cities",
                newName: "tempruter");
        }
    }
}

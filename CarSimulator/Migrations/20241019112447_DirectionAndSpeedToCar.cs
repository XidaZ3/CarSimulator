using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSimulator.Migrations
{
    /// <inheritdoc />
    public partial class DirectionAndSpeedToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Cars");
        }
    }
}

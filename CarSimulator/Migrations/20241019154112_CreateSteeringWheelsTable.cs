using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSimulator.Migrations
{
    /// <inheritdoc />
    public partial class CreateSteeringWheelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodies_Cars_CarId",
                table: "Bodies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bodies",
                table: "Bodies");

            migrationBuilder.RenameTable(
                name: "Bodies",
                newName: "Body");

            migrationBuilder.RenameIndex(
                name: "IX_Bodies_CarId",
                table: "Body",
                newName: "IX_Body_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Body",
                table: "Body",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SteeringWheel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteeringWheel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteeringWheel_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SteeringWheel_BodyId",
                table: "SteeringWheel",
                column: "BodyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Body_Cars_CarId",
                table: "Body",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Body_Cars_CarId",
                table: "Body");

            migrationBuilder.DropTable(
                name: "SteeringWheel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Body",
                table: "Body");

            migrationBuilder.RenameTable(
                name: "Body",
                newName: "Bodies");

            migrationBuilder.RenameIndex(
                name: "IX_Body_CarId",
                table: "Bodies",
                newName: "IX_Bodies_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bodies",
                table: "Bodies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodies_Cars_CarId",
                table: "Bodies",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

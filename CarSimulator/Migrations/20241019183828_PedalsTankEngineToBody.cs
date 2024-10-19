using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSimulator.Migrations
{
    /// <inheritdoc />
    public partial class PedalsTankEngineToBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accelerator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accelerator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accelerator_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brake",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brake_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engine_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    FuelAmount = table.Column<int>(type: "int", nullable: false),
                    BodyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tank_Body_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accelerator_BodyId",
                table: "Accelerator",
                column: "BodyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brake_BodyId",
                table: "Brake",
                column: "BodyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engine_BodyId",
                table: "Engine",
                column: "BodyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tank_BodyId",
                table: "Tank",
                column: "BodyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accelerator");

            migrationBuilder.DropTable(
                name: "Brake");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Tank");
        }
    }
}

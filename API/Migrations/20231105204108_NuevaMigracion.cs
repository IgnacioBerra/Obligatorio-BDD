using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    logId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    password = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.logId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "periodos_actualizacion",
                columns: table => new
                {
                    fechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodos_actualizacion", x => new { x.fechaInicio, x.fechaFin });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.CI);
                    table.ForeignKey(
                        name: "FK_funcionarios_logins_logId",
                        column: x => x.logId,
                        principalTable: "logins",
                        principalColumn: "logId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "agenda",
                columns: table => new
                {
                    nro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CI = table.Column<int>(type: "int", nullable: false),
                    fechaAgenda = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda", x => x.nro);
                    table.ForeignKey(
                        name: "FK_agenda_funcionarios_CI",
                        column: x => x.CI,
                        principalTable: "funcionarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carnet_salud",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    fechaEmision = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Comprobante = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carnet_salud", x => new { x.CI, x.fechaEmision });
                    table.ForeignKey(
                        name: "FK_carnet_salud_funcionarios_CI",
                        column: x => x.CI,
                        principalTable: "funcionarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_agenda_CI",
                table: "agenda",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_logId",
                table: "funcionarios",
                column: "logId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agenda");

            migrationBuilder.DropTable(
                name: "carnet_salud");

            migrationBuilder.DropTable(
                name: "periodos_actualizacion");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "logins");
        }
    }
}

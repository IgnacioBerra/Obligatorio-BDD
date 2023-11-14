using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    logId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.logId);
                });

            migrationBuilder.CreateTable(
                name: "periodos_actualizacion",
                columns: table => new
                {
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodos_actualizacion", x => new { x.fechaInicio, x.fechaFin });
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "actualizacion_funcionario",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actualizacion_funcionario", x => x.CI);
                    table.ForeignKey(
                        name: "FK_actualizacion_funcionario_funcionarios_CI",
                        column: x => x.CI,
                        principalTable: "funcionarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agenda",
                columns: table => new
                {
                    nro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<int>(type: "int", nullable: false),
                    fechaAgenda = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "carnet_salud",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    fechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comprobante = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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
                });

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
                name: "actualizacion_funcionario");

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

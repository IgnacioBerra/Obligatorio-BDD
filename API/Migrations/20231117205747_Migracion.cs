using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "periodos_actualizacion",
                columns: table => new
                {
                    Fch_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fch_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodos_actualizacion", x => new { x.Fch_Inicio, x.Fch_Fin });
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Fch_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.CI);
                    table.ForeignKey(
                        name: "FK_funcionarios_logins_LogId",
                        column: x => x.LogId,
                        principalTable: "logins",
                        principalColumn: "LogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "actualizacion",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false),
                    FuncCI = table.Column<int>(type: "int", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    completado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actualizacion", x => x.CI);
                    table.ForeignKey(
                        name: "FK_actualizacion_funcionarios_FuncCI",
                        column: x => x.FuncCI,
                        principalTable: "funcionarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agenda",
                columns: table => new
                {
                    Nro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fch_Agenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agenda", x => x.Nro);
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
                    Fch_Emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fch_Vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comprobante = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FuncCI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carnet_salud", x => new { x.CI, x.Fch_Emision });
                    table.ForeignKey(
                        name: "FK_carnet_salud_funcionarios_FuncCI",
                        column: x => x.FuncCI,
                        principalTable: "funcionarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_actualizacion_FuncCI",
                table: "actualizacion",
                column: "FuncCI");

            migrationBuilder.CreateIndex(
                name: "IX_agenda_CI",
                table: "agenda",
                column: "CI");

            migrationBuilder.CreateIndex(
                name: "IX_carnet_salud_FuncCI",
                table: "carnet_salud",
                column: "FuncCI");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_LogId",
                table: "funcionarios",
                column: "LogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actualizacion");

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

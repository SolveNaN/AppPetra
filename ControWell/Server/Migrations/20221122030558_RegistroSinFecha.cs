using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class RegistroSinFecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PozoId = table.Column<int>(type: "int", nullable: false),
                    VariableProcesoId = table.Column<int>(type: "int", nullable: false),
                    Medida = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Pozos_PozoId",
                        column: x => x.PozoId,
                        principalTable: "Pozos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_VariableProcesos_VariableProcesoId",
                        column: x => x.VariableProcesoId,
                        principalTable: "VariableProcesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Registros",
                columns: new[] { "Id", "FechaHora", "Medida", "PozoId", "VariableProcesoId" },
                values: new object[] { 1, null, 45f, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_PozoId",
                table: "Registros",
                column: "PozoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_VariableProcesoId",
                table: "Registros",
                column: "VariableProcesoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class Migraciondealarmas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozoId = table.Column<int>(type: "int", nullable: false),
                    VariableProcesoId = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<float>(type: "real", nullable: false),
                    Min = table.Column<float>(type: "real", nullable: false),
                    Habilitado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarmas_Pozos_PozoId",
                        column: x => x.PozoId,
                        principalTable: "Pozos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarmas_VariableProcesos_VariableProcesoId",
                        column: x => x.VariableProcesoId,
                        principalTable: "VariableProcesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alarmas",
                columns: new[] { "Id", "Habilitado", "Max", "Min", "PozoId", "VariableProcesoId" },
                values: new object[] { 1, 0, 500f, 30f, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmas_PozoId",
                table: "Alarmas",
                column: "PozoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmas_VariableProcesoId",
                table: "Alarmas",
                column: "VariableProcesoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarmas");
        }
    }
}

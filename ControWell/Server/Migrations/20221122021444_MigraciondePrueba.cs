using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class MigraciondePrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pruebas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pruebas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Autorizado" });

            migrationBuilder.UpdateData(
                table: "VariableProcesos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Unidad",
                value: "psia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pruebas");

            migrationBuilder.UpdateData(
                table: "VariableProcesos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Unidad",
                value: "pisa");
        }
    }
}

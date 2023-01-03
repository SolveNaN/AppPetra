using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class ConVariablesProceso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VariableProcesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableProcesos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VariableProcesos",
                columns: new[] { "Id", "Nombre", "Unidad" },
                values: new object[] { 1, "Presion Cabeza", "pisa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariableProcesos");
        }
    }
}

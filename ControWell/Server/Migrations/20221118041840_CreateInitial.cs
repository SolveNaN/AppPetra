using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePozo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operadora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tanques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTanque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoFluido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AforoTKs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TanqueId = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Volunen = table.Column<int>(type: "int", nullable: false),
                    TempBase = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AforoTKs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AforoTKs_Tanques_TanqueId",
                        column: x => x.TanqueId,
                        principalTable: "Tanques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pozos",
                columns: new[] { "Id", "Comentario", "NombrePozo", "Operadora", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Pozo en produccion", "CH-245 B", "Ecopetrol", "Chichimene" },
                    { 2, "Pozo en suspendido", "CH-215 A2", "Halliburton", "Chichimene" },
                    { 3, "Pozo en pruebas extensas", "CH-98", "Ecopetrol", "Chichimene" }
                });

            migrationBuilder.InsertData(
                table: "Tanques",
                columns: new[] { "Id", "Capacidad", "NombreTanque", "TipoFluido" },
                values: new object[,]
                {
                    { 1, "1000", "TK-915 NF", "Nafta" },
                    { 2, "2000", "TK-98 OL", "Petroleo" },
                    { 3, "1000", "TK-103 WT", "Agua" }
                });

            migrationBuilder.InsertData(
                table: "AforoTKs",
                columns: new[] { "Id", "Material", "Nivel", "TanqueId", "TempBase", "Volunen" },
                values: new object[] { 1, "acero", 100, 2, 120, 1000 });

            migrationBuilder.CreateIndex(
                name: "IX_AforoTKs_TanqueId",
                table: "AforoTKs",
                column: "TanqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AforoTKs");

            migrationBuilder.DropTable(
                name: "Pozos");

            migrationBuilder.DropTable(
                name: "Tanques");
        }
    }
}

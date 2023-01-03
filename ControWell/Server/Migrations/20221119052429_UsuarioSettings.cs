using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControWell.Server.Migrations
{
    public partial class UsuarioSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoAcceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cargo", "Cedula", "Nombre", "TipoAcceso" },
                values: new object[] { 1, "Sanchez", "Inpector de medicion", 1002, "Dagoberto", 1 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cargo", "Cedula", "Nombre", "TipoAcceso" },
                values: new object[] { 2, "Rojas", "Gefe de personal", 1245, "Angelo", 2 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Cargo", "Cedula", "Nombre", "TipoAcceso" },
                values: new object[] { 3, "Morales", "Lider de medicion", 850014, "Fabian", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

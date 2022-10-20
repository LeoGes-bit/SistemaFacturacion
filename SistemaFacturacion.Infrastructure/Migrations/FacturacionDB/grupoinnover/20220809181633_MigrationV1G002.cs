using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaFacturacion.Infrastructure.Data.Migrations.FacturacionDb.grupoinnover
{
    public partial class MigrationV1G002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "adm");

            migrationBuilder.CreateTable(
                name: "Catalogos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCatalogos",
                schema: "adm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCatalogo = table.Column<int>(type: "int", nullable: false),
                    Secuencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCatalogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCatalogos_Catalogos_IdCatalogo",
                        column: x => x.IdCatalogo,
                        principalSchema: "adm",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCatalogos_IdCatalogo",
                schema: "adm",
                table: "DetalleCatalogos",
                column: "IdCatalogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCatalogos",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "Catalogos",
                schema: "adm");
        }
    }
}

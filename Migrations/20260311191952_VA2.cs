using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Facturacion_Electronica.Migrations
{
    /// <inheritdoc />
    public partial class VA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdInfo",
                table: "Facturas",
                newName: "InfoTributariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_InfoTributariaId",
                table: "Facturas",
                column: "InfoTributariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_InfoTributaria_InfoTributariaId",
                table: "Facturas",
                column: "InfoTributariaId",
                principalTable: "InfoTributaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_InfoTributaria_InfoTributariaId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_InfoTributariaId",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "InfoTributariaId",
                table: "Facturas",
                newName: "IdInfo");
        }
    }
}

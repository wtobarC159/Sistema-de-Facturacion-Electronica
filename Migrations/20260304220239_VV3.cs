using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Facturacion_Electronica.Migrations
{
    /// <inheritdoc />
    public partial class VV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoTributaria_Facturas_IdFactura",
                table: "InfoTributaria");

            migrationBuilder.DropIndex(
                name: "IX_InfoTributaria_IdFactura",
                table: "InfoTributaria");

            migrationBuilder.DropColumn(
                name: "IdFactura",
                table: "InfoTributaria");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdInfo",
                table: "Facturas",
                column: "IdInfo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_InfoTributaria_IdInfo",
                table: "Facturas",
                column: "IdInfo",
                principalTable: "InfoTributaria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_InfoTributaria_IdInfo",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_IdInfo",
                table: "Facturas");

            migrationBuilder.AddColumn<int>(
                name: "IdFactura",
                table: "InfoTributaria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InfoTributaria_IdFactura",
                table: "InfoTributaria",
                column: "IdFactura",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTributaria_Facturas_IdFactura",
                table: "InfoTributaria",
                column: "IdFactura",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

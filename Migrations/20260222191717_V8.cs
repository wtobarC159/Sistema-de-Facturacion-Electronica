using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Facturacion_Electronica.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "AuditoriaPagos",
                newName: "UsuarioApp");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "AuditoriaFacturas",
                newName: "UsuarioApp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioApp",
                table: "AuditoriaPagos",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioApp",
                table: "AuditoriaFacturas",
                newName: "Usuario");
        }
    }
}

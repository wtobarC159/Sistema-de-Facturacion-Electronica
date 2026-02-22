using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Facturacion_Electronica.Migrations
{
    /// <inheritdoc />
    public partial class V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AuditoriaPagos",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "AuditoriaFacturas",
                newName: "Usuario");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaPago",
                table: "Pagos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "AuditoriaPagos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "AuditoriaFacturas",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "Pagos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}

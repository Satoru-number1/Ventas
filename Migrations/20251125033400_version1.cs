using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Cliente_IdCliente",
                table: "Visita");

            migrationBuilder.DropForeignKey(
                name: "FK_Visita_Semana_IdSemana",
                table: "Visita");

            migrationBuilder.DropIndex(
                name: "IX_Visita_IdCliente",
                table: "Visita");

            migrationBuilder.DropIndex(
                name: "IX_Visita_IdSemana",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "IdSemana",
                table: "Visita");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "Notas",
                table: "Visita",
                newName: "Nota");

            migrationBuilder.AddColumn<string>(
                name: "CodigoDireccion",
                table: "Direccion",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PedidoVisita",
                columns: table => new
                {
                    VisitaId = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoVisita", x => x.VisitaId);
                    table.ForeignKey(
                        name: "FK_PedidoVisita_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoVisita_Visita_VisitaId",
                        column: x => x.VisitaId,
                        principalTable: "Visita",
                        principalColumn: "IdVisita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoVisita_PedidoId",
                table: "PedidoVisita",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoVisita");

            migrationBuilder.DropColumn(
                name: "CodigoDireccion",
                table: "Direccion");

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "Visita",
                newName: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Visita",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Visita",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSemana",
                table: "Visita",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaVencimiento",
                table: "Producto",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdCliente",
                table: "Visita",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdSemana",
                table: "Visita",
                column: "IdSemana");

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Cliente_IdCliente",
                table: "Visita",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visita_Semana_IdSemana",
                table: "Visita",
                column: "IdSemana",
                principalTable: "Semana",
                principalColumn: "IdSemana",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

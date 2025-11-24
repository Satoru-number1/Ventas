using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class part6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Pedido_PedidoIdPedido",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_PedidoIdPedido",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "PedidoIdPedido",
                table: "Venta");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPedido",
                table: "Venta",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Pedido_IdPedido",
                table: "Venta",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Pedido_IdPedido",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdPedido",
                table: "Venta");

            migrationBuilder.AddColumn<int>(
                name: "PedidoIdPedido",
                table: "Venta",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_PedidoIdPedido",
                table: "Venta",
                column: "PedidoIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Pedido_PedidoIdPedido",
                table: "Venta",
                column: "PedidoIdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

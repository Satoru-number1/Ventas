using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class part2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoIdPedido",
                table: "DetallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Producto_ProductoIdProducto",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_PedidoIdPedido",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_ProductoIdProducto",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "PedidoIdPedido",
                table: "DetallePedido");

            migrationBuilder.DropColumn(
                name: "ProductoIdProducto",
                table: "DetallePedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdPedido",
                table: "DetallePedido",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_IdPedido",
                table: "DetallePedido",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Producto_IdPedido",
                table: "DetallePedido",
                column: "IdPedido",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Pedido_IdPedido",
                table: "DetallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Producto_IdPedido",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_IdPedido",
                table: "DetallePedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoIdPedido",
                table: "DetallePedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoIdProducto",
                table: "DetallePedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoIdPedido",
                table: "DetallePedido",
                column: "PedidoIdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoIdProducto",
                table: "DetallePedido",
                column: "ProductoIdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Pedido_PedidoIdPedido",
                table: "DetallePedido",
                column: "PedidoIdPedido",
                principalTable: "Pedido",
                principalColumn: "IdPedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Producto_ProductoIdProducto",
                table: "DetallePedido",
                column: "ProductoIdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

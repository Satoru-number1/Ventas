using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class part3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Producto_IdPedido",
                table: "DetallePedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdProducto",
                table: "DetallePedido",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Producto_IdProducto",
                table: "DetallePedido",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedido_Producto_IdProducto",
                table: "DetallePedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedido_IdProducto",
                table: "DetallePedido");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedido_Producto_IdPedido",
                table: "DetallePedido",
                column: "IdPedido",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

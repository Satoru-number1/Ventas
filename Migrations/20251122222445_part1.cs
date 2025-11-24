using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class part1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaBaja");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPedido",
                table: "Pedido",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Direccion",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Direccion",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoPedido",
                table: "Pedido",
                column: "CodigoPedido",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedido_CodigoPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CodigoPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Direccion");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Direccion");

            migrationBuilder.CreateTable(
                name: "VentaBaja",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoIdProducto = table.Column<int>(type: "integer", nullable: false),
                    CampanaCreada = table.Column<bool>(type: "boolean", nullable: false),
                    FechaAlerta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdProducto = table.Column<int>(type: "integer", nullable: false),
                    Razon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaBaja", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_VentaBaja_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaBaja_ProductoIdProducto",
                table: "VentaBaja",
                column: "ProductoIdProducto");
        }
    }
}

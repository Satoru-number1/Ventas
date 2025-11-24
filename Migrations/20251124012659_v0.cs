using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MicroServicioVentas.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ci = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombrePais = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    NombreProducto = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Promocion",
                columns: table => new
                {
                    IdPromocion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoPromocion = table.Column<string>(type: "text", nullable: false),
                    NombrePromocion = table.Column<string>(type: "text", nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocion", x => x.IdPromocion);
                });

            migrationBuilder.CreateTable(
                name: "Semana",
                columns: table => new
                {
                    IdSemana = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiaSemana = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semana", x => x.IdSemana);
                });

            migrationBuilder.CreateTable(
                name: "Correo",
                columns: table => new
                {
                    IdCorreo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "integer", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correo", x => x.IdCorreo);
                    table.ForeignKey(
                        name: "FK_Correo_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPais = table.Column<int>(type: "integer", nullable: false),
                    NombreDireccion = table.Column<string>(type: "text", nullable: false),
                    DireccionCompleta = table.Column<string>(type: "text", nullable: false),
                    IdDependiente = table.Column<int>(type: "integer", nullable: true),
                    Latitud = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitud = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoPedido = table.Column<string>(type: "text", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdEmpleado = table.Column<int>(type: "integer", nullable: false),
                    IdPromocion = table.Column<int>(type: "integer", nullable: false),
                    IdDireccion = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Direccion_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Promocion_IdPromocion",
                        column: x => x.IdPromocion,
                        principalTable: "Promocion",
                        principalColumn: "IdPromocion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    IdVisita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdEmpleado = table.Column<int>(type: "integer", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdSemana = table.Column<int>(type: "integer", nullable: false),
                    IdDireccion = table.Column<int>(type: "integer", nullable: false),
                    Notas = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.IdVisita);
                    table.ForeignKey(
                        name: "FK_Visita_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visita_Direccion_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visita_Semana_IdSemana",
                        column: x => x.IdSemana,
                        principalTable: "Semana",
                        principalColumn: "IdSemana",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    IdDetallePedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPedido = table.Column<int>(type: "integer", nullable: false),
                    IdProducto = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Descuento = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.IdDetallePedido);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPedido = table.Column<int>(type: "integer", nullable: false),
                    CodigoTransaccion = table.Column<int>(type: "integer", nullable: false),
                    FechaVenta = table.Column<DateOnly>(type: "date", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Ci",
                table: "Cliente",
                column: "Ci",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Correo_ClienteIdCliente",
                table: "Correo",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Correo_CorreoElectronico",
                table: "Correo",
                column: "CorreoElectronico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdPedido",
                table: "DetallePedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdProducto",
                table: "DetallePedido",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_IdPais",
                table: "Direccion",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoPedido",
                table: "Pedido",
                column: "CodigoPedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdDireccion",
                table: "Pedido",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdPromocion",
                table: "Pedido",
                column: "IdPromocion");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Codigo",
                table: "Producto",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_CodigoTransaccion",
                table: "Venta",
                column: "CodigoTransaccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdPedido",
                table: "Venta",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdCliente",
                table: "Visita",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdDireccion",
                table: "Visita",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Visita_IdSemana",
                table: "Visita",
                column: "IdSemana");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correo");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Visita");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Semana");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Promocion");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}

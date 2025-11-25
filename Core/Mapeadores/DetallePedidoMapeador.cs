using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using System.Threading.Tasks;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class DetallePedidoMapeador
    {
        public static DetallePedidoDTO toDetallePedidoDTO(this DetallePedido detallePedido)
        {
            return new DetallePedidoDTO()
            {
                CodigoProducto = detallePedido.Producto.Codigo,
                NombreProducto = detallePedido.Producto.NombreProducto,
                Cantidad = detallePedido.Cantidad,
                PrecioUnitario = detallePedido.Producto.Precio,
                Total = detallePedido.Total,
                Subtotal = detallePedido.SubTotal
            };
        }
        public static DetallesPedidoDistribuidora toDetallePedidoToDetallesPedidoDistribuidora(this DetallePedido detallePedido)
        {
            return new DetallesPedidoDistribuidora()
            {
                CodigoProducto = detallePedido.Producto.Codigo,
                Cantidad = detallePedido.Cantidad,
                PrecioUnitario = detallePedido.Producto.Precio,
                Subtotal = detallePedido.SubTotal
            };
        }
    }
}

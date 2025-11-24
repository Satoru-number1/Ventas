using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class VentaMapeador
    {
        public static VentaDTO toVentaDTO(this Venta venta)
        {
            return new VentaDTO()
            {
                CodigoVenta = venta.CodigoTransaccion,
                CodigoPedido = venta.Pedido.CodigoPedido,
                Fecha = venta.FechaVenta,
                MontoTotal = venta.MontoTotal,
                DetallesVenta = venta.Pedido.DetallesPedido
                                    .Select(detalle => detalle.toDetallePedidoDTO())
                                    .ToList()
            };
        }
    }
}

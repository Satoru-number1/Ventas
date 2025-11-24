using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class PedidoMapeador
    {
        public static PedidoDTO toPedidoDTO(this Pedido pedido)
        {
            return new PedidoDTO()
            {
                CodigoPedido= pedido.CodigoPedido,
                IdentificadorEmpleado = pedido.IdEmpleado,
                NombreCliente = pedido.Cliente.Nombre,
                CodigoPromocion = pedido.Promocion.CodigoPromocion,
                DireccionEnvio = pedido.Direccion.DireccionCompleta,
                FechaEntrega = pedido.FechaPedido,
                Pedidos = pedido.DetallesPedido.Select(dt=>dt.toDetallePedidoDTO()).ToList()
            };
        }
    }
}

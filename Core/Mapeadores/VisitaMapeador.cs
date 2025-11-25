using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class VisitaMapeador
    {
        public static VisitaDTO toVisitaDTO(this Visita visita)
        {
            return new VisitaDTO() {
                
            };
        }
        public static VisitaSucursalDOT toVisitaSucursalDTO(this Visita visita)
        {
            return new VisitaSucursalDOT()
            {
                CodigoRuta = visita.Direccion.CodigoDireccion,
                Fecha = visita.FechaVisita,
                PedidosDistribuidora = visita.Pedidos
                    .Select(pv => new PedidoDistribuidora
                    {
                        CodigoPedido = pv.Pedido.CodigoPedido,
                        FechaEntrega = pv.Pedido.FechaPedido,
                        DireccionEnvio = pv.Pedido.Direccion.DireccionCompleta,
                    })
                    .ToList()
                
            };
        }
    }
}

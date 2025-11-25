using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicioVentas.Core.Interface
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoDistribuidora>> GetPedidos();
        Task<List<PedidoDTO>> GetPedidosAll();
        Task<List<PedidoDistribuidora>> GetPedidosCancelados();
        Task<List<PedidoDistribuidora>> GetPedidosEntregados();

        Task<PedidoDTO> PostPedido(string codigoPedido,int codigoEmpleado, string nombreCLiente, string ci, string codigoPromocion, string envioDireccion, string fechaEntrega);
        Task<IActionResult> PutPedido(string estado, string codigoPedido);
        Task<IActionResult> PutPedidoEntregado( string codigoPedido);
    }
}

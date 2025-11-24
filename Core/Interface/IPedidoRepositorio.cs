using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicioVentas.Core.Interface
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoDTO>> GetPedidos();
        Task<PedidoDTO> PostPedido(string codigoPedido,int codigoEmpleado, string nombreCLiente, string ci, string codigoPromocion, string envioDireccion, string fechaEntrega);
        Task<IActionResult> PutPedido(string estado, string codigoPedido);
    }
}

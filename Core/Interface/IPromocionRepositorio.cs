using MicroServicioVentas.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicioVentas.Core.Interface
{
    public interface IPromocionRepositorio
    {
        Task<List<PromocionDTO>> GetPromociones();
        Task<List<CampanaDTO>> GetCampanaActual();
        Task<IActionResult> DeletePromocion(string codigoPromocion);
        Task<PromocionDTO> PostPromocion(PromocionDTO promocion);
    }
}

using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicioVentas.Core.Interface
{
    public interface IDireccionRepositorio
    {
        Task<List<DireccionDTO>> GetDireccion();
        Task<IActionResult> PostDireccion(string direccion,string codigoD,decimal latitud,decimal longitud);
    }
}

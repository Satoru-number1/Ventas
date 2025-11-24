using MicroServicioVentas.Core.DTO;

namespace MicroServicioVentas.Core.Interface
{
    public interface ICorreoRepositorio
    {
        Task<List<CorreoCIDTO>> GetCorreo();
    }
}

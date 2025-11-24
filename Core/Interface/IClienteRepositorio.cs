using MicroServicioVentas.Core.DTO;

namespace MicroServicioVentas.Core.Interface
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDTO>> GetCLiente();
        Task<ClienteDTO> PostCliente(string ci, string nombre, string apellidop, string apellidom, string correo);
    }
}

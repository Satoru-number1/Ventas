using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class ClienteMapeador
    {
        //Convierte los datos de la entidad Cliente a un ClienteDTO
        public static ClienteDTO toClienteDTO(this Cliente cliente)
        {
            return new ClienteDTO()
            {
                Ci = cliente.Ci,
                Nombre = cliente.Nombre,
                ApellidoPaterno = cliente.ApellidoPaterno,
                ApellidoMaterno = cliente.ApellidoMaterno,
                Correos = cliente.Correos.Select(correo => correo.toCorreoDTO()).ToList()
            };
        }
    }
}

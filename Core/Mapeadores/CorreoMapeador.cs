using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class CorreoMapeador
    {
        public static CorreoDTO toCorreoDTO(this Correo correo)
        {
            return new CorreoDTO()
            {
                CorreoElectronico = correo.CorreoElectronico
            };

        }
        public static CorreoCIDTO toCorreoCIDTO(this Correo correo)
        {
            return new CorreoCIDTO()
            {
                CorreoElectronico = correo.CorreoElectronico,
                CI = correo.Cliente.Ci,
                Nombre = correo.Cliente.Nombre
            };
        }
    }
}

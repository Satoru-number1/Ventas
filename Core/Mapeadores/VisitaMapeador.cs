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
                IdEmpleado = visita.IdEmpleado,
                Ci = visita.Cliente.Ci,
                NombreCliente = visita.Cliente.Nombre,
                DiaSemana = visita.DiaSemana.DiaSemana,
                DireccionCompleta = visita.Direccion.DireccionCompleta,
                Latitud = visita.Direccion.Latitud,
                Longitud = visita.Direccion.Longitud
            };
        }
    }
}

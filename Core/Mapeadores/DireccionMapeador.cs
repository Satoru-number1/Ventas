using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class DireccionMapeador
    {
        public static DireccionDTO toDireccionDTO(this Direccion direccion)
        {
            return new DireccionDTO()
            {
                CodigoDireccion = direccion.CodigoDireccion,
                DireccionCompleta = direccion.NombreDireccion,
                IdDependiente = direccion.IdDependiente 
            };
        }
        public static OnlyDireccionDTO toOnlyDireccionDTO(this Direccion direccion)
        {
            return new OnlyDireccionDTO()
            {
                DireccionCompleta = direccion.NombreDireccion
            };
        }
    }
}

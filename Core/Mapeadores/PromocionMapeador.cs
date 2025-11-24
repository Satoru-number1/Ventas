using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class PromocionMapeador
    {
        public static PromocionDTO toPromocionDTO(this Promocion promocion)
        {
            return new PromocionDTO()
            {
                CodigoPromocion = promocion.CodigoPromocion,
                NombrePromocion = promocion.NombrePromocion,
                Descripcion = promocion.Descripcion,
                Descuento = promocion.Descuento,
                FechaInicio = promocion.FechaInicio,
                FechaFin = promocion.FechaFin
            };
        }
    }
}

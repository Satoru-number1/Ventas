namespace MicroServicioVentas.Core.DTO
{

    public class PromocionDTO
    {
        public string CodigoPromocion { get; set; }
        public string NombrePromocion { get; set; } 
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
    }
    public class CampanaDTO
    {
        public string CodigoPromocion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaFin { get; set; }
    }
}

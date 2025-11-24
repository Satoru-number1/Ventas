using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    public class Promocion
    {
        [Key]
        public int IdPromocion { get; set; }
        
        public string CodigoPromocion { get; set; }
        public string NombrePromocion { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string Estado { get; set; }="Activo";
    }
}

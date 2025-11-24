namespace MicroServicioVentas.Core.DTO
{
    public class ProductoDTO
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }   
        public DateOnly FechaVencimiento { get; set; }
    }

}

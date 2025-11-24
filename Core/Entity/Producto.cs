using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    [Index(nameof(Codigo),IsUnique =true)]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public ICollection<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>();
        public DateOnly FechaVencimiento { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    [Index(nameof(CodigoTransaccion),IsUnique =true)]
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        public int CodigoTransaccion { get; set; }
        public DateOnly FechaVenta { get; set; } = DateOnly.FromDateTime( DateTime.Now);
        public decimal MontoTotal { get; set; }
    }
}

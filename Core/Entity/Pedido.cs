using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    [Index(nameof(CodigoPedido), IsUnique =true) ]
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public string CodigoPedido { get; set; }
        public int IdCliente { get; set; }
        //lo mismo que detalles pedido, acceder a las propiedades de la clase cliente
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdPromocion { get; set; }
        //propiedad de navegacion para la relacion con Promocion
        [ForeignKey(nameof(IdPromocion))]
        public Promocion Promocion { get; set; }

        public int IdDireccion { get; set; }
        //acceder a las propiedades de la clase Direccion
        [ForeignKey(nameof(IdDireccion))]
        public Direccion Direccion { get; set; }
        public string Estado { get; set; } = "Proceso";
        public DateOnly FechaCreacion { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly FechaPedido { get; set; }

        //propiedad de navegacion para la relacion con DetallePedido, la inicializo, por que por ejemplo al crear un pedido nuevo y
        //      cuando quiera agregar detalles al pedido recien creado, no me de error de referencia nula
        //en cambio si no la inicializo, al crear un pedido nuevo y querer agregar detalles al pedido recien creado, me dara
        //      error de referencia nula
        public ICollection<DetallePedido> DetallesPedido { get; set; }= new List <DetallePedido>();
    }
}

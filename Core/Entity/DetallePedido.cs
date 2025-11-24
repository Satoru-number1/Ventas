using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    public class DetallePedido
    {
        [Key]
        public int IdDetallePedido { get; set; }

        public int IdPedido { get; set; }

        //para que sepa que hay una relacion con la clase Pedido, digamos para que acceda a sus propiedades
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey(nameof(IdProducto))]
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }   
        public decimal PrecioUnitario { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
}
 
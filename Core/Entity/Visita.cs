using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    public class Visita
    {
        [Key]
        public int IdVisita { get; set; }

        public int IdDireccion { get; set; }
        [ForeignKey(nameof(IdDireccion))]
        public Direccion Direccion { get; set; }
        public string Nota { get; set; } = "Entrega de pedido";
        public DateOnly FechaVisita { get; set; }
        public ICollection<PedidoVisita> Pedidos { get; set; }= new List<PedidoVisita>();


    }
}

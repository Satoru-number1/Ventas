using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
        public class PedidoVisita
        {
        [Key]
            public int VisitaId { get; set; }
            public int PedidoId { get; set; }

            // Propiedades de Navegación
            [ForeignKey(nameof(VisitaId))]
            public Visita Visita { get; set; }
            [ForeignKey(nameof(PedidoId))]
            public Pedido Pedido { get; set; }
        }
}

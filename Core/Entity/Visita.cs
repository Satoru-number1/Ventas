using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    public class Visita
    {
        [Key]
        public int IdVisita { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public Cliente Cliente { get; set; }
        public int IdSemana { get; set; }
        [ForeignKey(nameof(IdSemana))]  
        public Semana DiaSemana {get;set;}

        public int IdDireccion { get; set; }
        [ForeignKey(nameof(IdDireccion))]
        public Direccion Direccion { get; set; }
        public string Notas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    public class Semana
    {
        [Key]
        public int IdSemana { get; set; }
        public string DiaSemana { get; set; }
    }
}

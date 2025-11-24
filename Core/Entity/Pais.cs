using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
    }
}

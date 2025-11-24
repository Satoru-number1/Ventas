using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }
        public int IdPais {get;set;}
        //para acceder a las propiedades de la clase Pais
        [ForeignKey("IdPais")]
        public Pais Pais {get;set; }
        public string NombreDireccion { get; set; }
        public string DireccionCompleta { get; set; }
        public int? IdDependiente { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
    }
}

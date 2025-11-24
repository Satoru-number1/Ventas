using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicioVentas.Core.Entity
{

    [Index(nameof(Ci),IsUnique =true )]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; } 

        //propiedad de navegacion para la relacion con Correo
        public ICollection<Correo> Correos { get; set; } = new List<Correo>();
    }
}

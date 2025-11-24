using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    [Index(nameof(CorreoElectronico),IsUnique =true)]
    public class Correo
    {
        [Key]
        public int IdCorreo {get;set;}
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; } = "Activo";

    }
}

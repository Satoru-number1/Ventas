using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MicroServicioVentas.Core.Entity
{
    [Index(nameof(CodigoRuta), IsUnique = true)]
    public class Ruta
    {
        [Key]
        public int IdRuta { get; set; }

        public string CodigoRuta { get; set; }
        public DateOnly Fecha { get; set; }
    }
}

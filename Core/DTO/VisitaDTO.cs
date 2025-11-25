namespace MicroServicioVentas.Core.DTO
{
    public class VisitaDTO
    {
        public int IdEmpleado { get; set; }
        public string Ci { get; set; }
        public string NombreCliente { get; set; }
        public string DiaSemana { get; set; }
        public string DireccionCompleta { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

    }
    public class VisitaDistribuidora 
    {
        public string CodigoRuta { get; set; }

    }

}

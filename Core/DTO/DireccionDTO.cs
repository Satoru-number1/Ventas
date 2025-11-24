namespace MicroServicioVentas.Core.DTO
{
    public class DireccionDTO
    {
        public string DireccionCompleta { get; set; }
        public int? IdDependiente { get; set; }

    }
    public class OnlyDireccionDTO
    {
        public string DireccionCompleta { get; set; }  
    }
}

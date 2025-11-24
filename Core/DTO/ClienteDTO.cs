namespace MicroServicioVentas.Core.DTO
{
    public class ClienteDTO
    {
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<CorreoDTO> Correos { get; set; }
    }
}
    
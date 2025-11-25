namespace MicroServicioVentas.Core.DTO
{
    public class VisitaDTO
    {
        
        public string Id { get; set; }
    }
    
    public class PedidoResumenDto
    {
        public int PedidoId { get; set; }
        public string ClienteNombre { get; set; }
        public string DescripcionBreve { get; set; }
    }

    // DTO para cada ruta/visita en la lista
    public class RutaResumenDto
    {
        public int VisitaId { get; set; }
        public DateOnly FechaProgramada { get; set; }
        public string DireccionCompleta { get; set; }
        public string NotaDeRuta { get; set; }
        public List<PedidoResumenDto> Pedidos { get; set; }
    }
}

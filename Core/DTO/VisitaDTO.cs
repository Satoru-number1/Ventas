namespace MicroServicioVentas.Core.DTO
{
    public class VisitaDTO
    {
        
        public string Id { get; set; }
    }
    public class VisitaSucursalDOT
    {
        public string CodigoRuta { get; set; }
        public DateOnly Fecha { get; set; }
        public ICollection<PedidoDistribuidora> PedidosDistribuidora { get; set; }= new List<PedidoDistribuidora>();
    }




}

namespace MicroServicioVentas.Core.DTO
{
    public class VentaDTO
    {
        public int CodigoVenta { get; set; }
        public string CodigoPedido { get; set; }
        public DateOnly Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public List<DetallePedidoDTO> DetallesVenta { get; set; }
    }
    public class ProductoMenosVendidoDTO
    {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
    }
}

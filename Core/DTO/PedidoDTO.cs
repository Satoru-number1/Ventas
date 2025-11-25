using MicroServicioVentas.Core.Entity;
using NuGet.Packaging.Signing;

namespace MicroServicioVentas.Core.DTO
{
    public class PedidoDTO
    {
        public string CodigoPedido { get; set; }
        public int IdentificadorEmpleado { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoPromocion { get; set; }
        public string DireccionEnvio { get; set; }
        public DateTime FechaCreacion { get; set; }=DateTime.Now;
        //ejemplo de entrada DateTime miFecha = new DateTime(2024, 11, 10, 14, 30, 0); // 10 de noviembre de 2024 a las 14:30:00
        
        //DateTime miFecha = DateTime.ParseExact("10/11/2024", "dd/MM/yyyy", null);
        
        //string fechaComoCadena = "11/10/2024 14:30";
        //DateTime miFecha = DateTime.Parse(fechaComoCadena); // Requiere que el formato sea reconocido

        public DateOnly FechaEntrega { get; set; }
        public List<DetallePedidoDTO> Pedidos { get;set; }
    }
    public class DetallePedidoDTO
    {
        public string CodigoProducto { get; set; }     
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; } 
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

    }
    public class PedidoDistribuidora
    {
        public string CodigoPedido { get; set; }
        
        public string Estado { get; set; }
        public string DireccionEnvio { get; set; }
        public DateOnly FechaEntrega { get; set; }
    }
    public class DetallesPedidoDistribuidora
    {
        public string CodigoProducto { get; set; }     
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}

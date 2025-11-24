using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Core.Mapeadores
{
    public static class ProductoMapeador
    {
        public static ProductoDTO toProductoDTO(this Producto producto)
        {
            return new ProductoDTO()
            {
                Codigo = producto.Codigo,
                Nombre = producto.NombreProducto,
                Precio = producto.Precio,
                FechaVencimiento = producto.FechaVencimiento
            };
        }
    }
}

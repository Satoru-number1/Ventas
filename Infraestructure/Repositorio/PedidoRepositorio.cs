using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.InteropServices;

namespace MicroServicioVentas.Infraestructure.Repositorio
{
    public class PedidoRepositorio: IPedidoRepositorio
    {
        private readonly MicroServicioVentasContext _context;
        public PedidoRepositorio(MicroServicioVentasContext context)
        {
            _context = context;
        }

        public async Task<List<PedidoDTO>> GetPedidos()
        {
            var pedido = await (from p in _context.Pedido
                               where p.Estado=="Proceso" select p).
                               //aqui incluye la coleccion de los detalles
                               Include(p =>p.DetallesPedido).
                               //y aqui se incluye la propiedad del objeto producto dentro de cada detalle
                               ThenInclude(d=>d.Producto).
                               Include(p=>p.Promocion).
                               Include(p=>p.Cliente).
                               Include(d=>d.Direccion)

                .ToListAsync();


            var pedidoDTO = pedido.Select(p=>p.toPedidoDTO()).ToList();
            return pedidoDTO;
        }

        public async Task<PedidoDTO> PostPedido(string codigoPedido,int codigoEmpleado, string nombreCLiente, string ci, string codigoPromocion, string envioDireccion, string fechaEntrega)
        {
            //using var transaction = await _context.Database.BeginTransactionAsync();
            //try
            //{

                Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Nombre == nombreCLiente && c.Ci == ci);
                Promocion promocion = await _context.Promocion.FirstOrDefaultAsync(p => p.CodigoPromocion == codigoPromocion);
            //agregando los productos al detalle pedido

            
            //para verificar si existe una direccion, si no existe crear la direccion
            string[] partesDirecciones = envioDireccion.Split('/');
                int? idPadre = null;
                for (int i = 0; i < partesDirecciones.Length; i++)
                {
                    //verificar si existe la direccion
                    string direccionActual = partesDirecciones[i];
                    Direccion direccion = await _context.Direccion.FirstOrDefaultAsync(d => d.NombreDireccion == direccionActual && d.IdDependiente == idPadre);
                    //si existe el idpadre se actualiza de la direccion actual
                    if (direccion != null)
                    {
                        idPadre = direccion.IdDireccion;
                    }
                    //si no existe crea una nueva direccion y actualiza el idpadre
                    else
                    {
                        Direccion nuevaDireccion = new Direccion()
                        {
                            IdPais = (await _context.Pais.FirstOrDefaultAsync(p => p.NombrePais == "Bolivia")).IdPais,
                            NombreDireccion = direccionActual,
                            IdDependiente = idPadre,
                            DireccionCompleta = envioDireccion,
                        };
                        _context.Direccion.Add(nuevaDireccion);
                        await _context.SaveChangesAsync();
                        idPadre = nuevaDireccion.IdDireccion;
                    }


                }
                //convierte la fecha de entrega en un objeto DateOnly
                DateOnly fecha = DateOnly.ParseExact(fechaEntrega, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Pedido pedido = new Pedido()
                {
                    CodigoPedido = codigoPedido,
                    IdCliente = cliente.IdCliente,
                    IdEmpleado = codigoEmpleado,
                    IdPromocion = promocion.IdPromocion,
                    IdDireccion = idPadre.Value,
                    FechaPedido = fecha
                };
            //revisar si existe alguna promocion
            //decimal existPromo = (promocion!=null)?promocion.Descuento:1;
            //    decimal totalPedido = 0;
            //string[] listaProductos= productos.Split(',');
            //    for (int i = 0; i < listaProductos.Length; i++)
            //    {
            //        string producto = listaProductos[i].ToLower().Trim();
            //        var detallepedido = await (from p in _context.Producto
            //                                   where p.NombreProducto == producto
            //                                   select p).FirstOrDefaultAsync();
            //        DetallePedido detalle = new DetallePedido()
            //        {
            //            IdProducto = detallepedido.IdProducto,
            //            Cantidad = cantidad,
            //            IdPedido =pedido.IdPedido,
            //            Descuento= existPromo,
            //            SubTotal=(detallepedido.Precio * cantidad)*existPromo,
                        
            //        };
            //        totalPedido += detalle.SubTotal;
            //        if (i==listaProductos.Length-1)
            //        {
            //            detalle.Total=totalPedido;
            //        }
                    
            //    }
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return (pedido.toPedidoDTO());
            //    await transaction.CommitAsync();
            //    return pedido;
            //}
            //catch (Exception ex)
            //{
            //    await transaction.RollbackAsync();
                
            //    return new Pedido();}
            
        }

        public async Task<IActionResult> PutPedido(string estado,string codigoPedido)
        {
            var pedido = await (from p in _context.Pedido
                                where p.CodigoPedido == codigoPedido
                                select p).FirstOrDefaultAsync();
            pedido.Estado = estado;
            _context.SaveChangesAsync();

            return (IActionResult) pedido.toPedidoDTO();
        }
    }
}

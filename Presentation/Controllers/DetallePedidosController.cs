using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Infraestructure.Data;
using MicroServicioVentas.Core.Mapeadores;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly MicroServicioVentasContext _context;

        public DetallePedidosController(MicroServicioVentasContext context)
        {
            _context = context;
        }

        // GET: api/DetallePedidos
        [HttpGet]
        public async Task<IActionResult> GetDetallePedido()
        {
            return Ok(await _context.DetallePedido.Include(dp=>dp.Producto)
                          .Select(dp=>dp.toDetallePedidoToDetallesPedidoDistribuidora())
                          .ToListAsync());
        }
        /*
        // GET: api/DetallePedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }*/
        /*
        // PUT: api/DetallePedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.IdDetallePedido)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */
        // POST: api/DetallePedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(string codigoPedido,string codigoProducto, string producto, string cantidad, string promocion)
        {
            //revisar si existe alguna promocion

            decimal totalPedido = 0;
            string[]listaCodigosProducto=codigoProducto.Split(',');
            string[]listaProductos=producto.Split(',');
            string[] listaCantidad=cantidad.Split(",");
            int idPedido1= await (from p in _context.Pedido
                                  where p.CodigoPedido== codigoPedido
                                  select p.IdPedido).FirstOrDefaultAsync();
            var pro = await (from pr in _context.Promocion
                                 where pr.CodigoPromocion == promocion
                                 select pr).FirstOrDefaultAsync();
            decimal descuento = (pro != null) ? pro.Descuento : 0;
            descuento /= 100;
            for (int i = 0; i < listaProductos.Length; i++)
            {
                int cantidad1 = int.Parse( listaCantidad[i]);
                string producto1 = listaProductos[i].ToLower().Trim();
                var detallepedido = await (from p in _context.Producto
                                           where p.NombreProducto == producto1 && p.Codigo == listaCodigosProducto[i]
                                           select p).FirstOrDefaultAsync();
                

                DetallePedido detalle = new DetallePedido()
                {
                    IdProducto = detallepedido.IdProducto,
                    Cantidad = cantidad1,
                    IdPedido = idPedido1,
                    Descuento = (pro != null) ? pro.Descuento : 0,
                    SubTotal = (detallepedido.Precio * cantidad1) * Math.Abs(descuento - 1),
                    PrecioUnitario = detallepedido.Precio

                };
                totalPedido += detalle.SubTotal;
                if (i == listaProductos.Length - 1)
                {
                    detalle.Total = totalPedido;
                }
                
                
                

                _context.DetallePedido.Add(detalle);

            }
                await _context.SaveChangesAsync();

            return Ok();
        }
       
    
        


       
    }
}

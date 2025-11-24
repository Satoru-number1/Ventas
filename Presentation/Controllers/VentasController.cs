using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Infraestructure.Data;
using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Mapeadores;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly MicroServicioVentasContext _context;

        public VentasController(MicroServicioVentasContext context)
        {
            _context = context;
        }
        
        // GET: api/Ventas
        [HttpGet]
        public async Task<IActionResult> GetVenta()
        {
            var venta = await _context.Venta
                .Include(p => p.Pedido)
                    .ThenInclude(d => d.DetallesPedido)
                        .ThenInclude(p => p.Producto).Select(v=>v.toVentaDTO()).ToListAsync();
            return Ok(venta);
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Venta.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }
        [HttpGet("ProductosMenosVendidos")]
        public async Task<IActionResult> GetProductosMenosVendidos()
        {
            var fechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)); // Última semana días
            var productosMenosVendidos = await _context.Venta
                .Where(v => v.FechaVenta >= fechaInicio)
                .SelectMany(v => v.Pedido.DetallesPedido)
                .GroupBy(dp => new {
                    Codigo=dp.Producto.Codigo,
                    Nombre=dp.Producto.NombreProducto


                })
                .Select(g=> new ProductoMenosVendidoDTO
                {
                    CodigoProducto=g.Key.Codigo,
                    NombreProducto=g.Key.Nombre,
                    CantidadVendida=g.Sum(dp=>dp.Cantidad)
                })
                .OrderBy(dto=>dto.CantidadVendida)
                .Take(10).
                ToListAsync();

            /*.Include(v => v.Pedido)
                .ThenInclude(p => p.DetallesPedido)
                    .ThenInclude(dp => dp.Producto)
            .SelectMany(v => v.Pedido.DetallesPedido)
            .GroupBy(dp => new{
                Id=dp.Producto.Codigo,
                Nombre=dp.Producto.NombreProducto
            })
            .Select(g=> new ProductoMenosVendidoDTO
            {
                CodigoProducto=g.Key.Id,
                NombreProducto=g.Key.Nombre,
                CantidadVendida=g.Sum(dp=>dp.Cantidad)
            })
            .OrderBy(dto=>dto.CantidadVendida)
            .Take(5)
            .ToListAsync();*/
            return Ok(productosMenosVendidos);
        }


        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            

            return NoContent();
        }

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostVenta(int idPedido,int codigoTransaccion)
        {
            var pedido = await (from p in _context.Pedido
                                where p.IdPedido == idPedido
                                select p).FirstOrDefaultAsync();
            var detalle= await(from dt in _context.DetallePedido
                               where dt.IdPedido==idPedido
                               select dt).OrderBy(d=>d.IdDetallePedido).ToListAsync();
            var lastrow = detalle.LastOrDefault();
            decimal ventaTotal=lastrow.Total;
            Venta venta = new Venta()
            {
                IdPedido = idPedido,
                CodigoTransaccion = codigoTransaccion,
                MontoTotal = ventaTotal
            };

            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /*
        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await _context.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Venta.Any(e => e.IdVenta == id);
        }*/
    }
}

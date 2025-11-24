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
using System.Globalization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MicroServicioVentas.Core.Interface;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepositorio _context;

        public PedidosController(IPedidoRepositorio context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<IActionResult> GetPedido()
        {
            var ped= await _context.GetPedidos();
            return Ok(ped);
        }

        /*// GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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
        // POST: api/Pedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPedido(string codigoPedido,int codigoEmpleado,string nombreCLiente,string ci,string codigoPromocion,string envioDireccion,string fechaEntrega)
        {
            var pedido=_context.PostPedido(codigoPedido,codigoEmpleado,  nombreCLiente,ci,codigoPromocion,envioDireccion,fechaEntrega);
            return Ok(await pedido);
        }

        [HttpPut]
        public async Task<IActionResult> PutActualizarEstadoPedido(string codigoPedido,string nuevoEstado)
        {
            var pedido = _context.PutPedido(nuevoEstado,codigoPedido);
            return Ok(await pedido);
        }

        /* // DELETE: api/Pedidos/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeletePedido(int id)
         {
             var pedido = await _context.Pedido.FindAsync(id);
             if (pedido == null)
             {
                 return NotFound();
             }

             _context.Pedido.Remove(pedido);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool PedidoExists(int id)
         {
             return _context.Pedido.Any(e => e.IdPedido == id);
         }*/
    }
}

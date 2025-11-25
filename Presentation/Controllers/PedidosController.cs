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
        //todos los pedidos
        [HttpGet]
        public async Task<IActionResult> GetPedidoAll()
        {
            var ped = await _context.GetPedidosAll();
            return Ok(ped);
        }
        // GET: api/Pedidos
        //solo los pedidos en proceso
        [HttpGet("PedidosEnProceso")]
        public async Task<IActionResult> GetPedido()
        {
            var ped = await _context.GetPedidos();
            return Ok(ped);
        }
        //pedidos entregados 
        [HttpGet("PedidosEntregados")]
        public async Task<IActionResult> GetPedidoEntregado()
        {
            var ped = await _context.GetPedidosEntregados();
            return Ok(ped);
        }
        //pedidos cancelados
        [HttpGet("PedidosCancelados")]
        public async Task<IActionResult> GetPedidoCancelados()
        {
            var ped = await _context.GetPedidosCancelados();
            return Ok(ped);
        }
        [HttpGet("{CodigoDireccion}")]
        public async Task<IActionResult> GetPedidoSegunRuta()
        {
            var ped = await _context.GetPedidosCancelados();
            return Ok(ped);
        }
       


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
        [HttpPut("PedidoEntregado/{codigoPedido}")]
        public async Task<IActionResult> PutPedidoEntregado([FromRoute]string codigoPedido)
        {
            var pedido = _context.PutPedidoEntregado(codigoPedido);
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

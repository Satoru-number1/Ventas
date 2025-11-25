using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Infraestructure.Data;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoVisitasController : ControllerBase
    {
        private readonly MicroServicioVentasContext _context;

        public PedidoVisitasController(MicroServicioVentasContext context)
        {
            _context = context;
        }

        // GET: api/PedidoVisitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoVisita>>> GetPedidoVisita()
        {
            return await _context.PedidoVisita.ToListAsync();
        }

        // GET: api/PedidoVisitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoVisita>> GetPedidoVisita(int id)
        {
            var pedidoVisita = await _context.PedidoVisita.FindAsync(id);

            if (pedidoVisita == null)
            {
                return NotFound();
            }

            return pedidoVisita;
        }

        // PUT: api/PedidoVisitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoVisita(int id, PedidoVisita pedidoVisita)
        {
            if (id != pedidoVisita.VisitaId)
            {
                return BadRequest();
            }

            _context.Entry(pedidoVisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoVisitaExists(id))
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

        // POST: api/PedidoVisitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoVisita>> PostPedidoVisita(PedidoVisita pedidoVisita)
        {
            _context.PedidoVisita.Add(pedidoVisita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PedidoVisitaExists(pedidoVisita.VisitaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPedidoVisita", new { id = pedidoVisita.VisitaId }, pedidoVisita);
        }

        // DELETE: api/PedidoVisitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoVisita(int id)
        {
            var pedidoVisita = await _context.PedidoVisita.FindAsync(id);
            if (pedidoVisita == null)
            {
                return NotFound();
            }

            _context.PedidoVisita.Remove(pedidoVisita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoVisitaExists(int id)
        {
            return _context.PedidoVisita.Any(e => e.VisitaId == id);
        }
    }
}

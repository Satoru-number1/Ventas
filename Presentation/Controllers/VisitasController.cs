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
    public class VisitasController : ControllerBase
    {
        private readonly MicroServicioVentasContext _context;

        public VisitasController(MicroServicioVentasContext context)
        {
            _context = context;
        }

        // GET: api/Visitas
        [HttpGet]
        public async Task<IActionResult> GetVisita()
        {
            return Ok();
        }
        [HttpGet("Rutas")]
        public async Task<IActionResult> GetRuta()
        {
            return Ok();
        }
        /*
        // GET: api/Visitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visita>> GetVisita(int id)
        {
            var visita = await _context.Visita.FindAsync(id);

            if (visita == null)
            {
                return NotFound();
            }

            return visita;
        }

        // PUT: api/Visitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisita(int id, Visita visita)
        {
            if (id != visita.IdVisita)
            {
                return BadRequest();
            }

            _context.Entry(visita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Visitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostVisita(int idEmpleado,string cliente,string ciCliente,string dia,string direccion, decimal latitud, decimal lontigud)
        {

            var clienteExistente = await _context.Cliente.FirstOrDefaultAsync(c => c.Ci == ciCliente && c.Nombre==cliente);
            var diaSemana = await _context.Semana.FirstOrDefaultAsync(d => d.DiaSemana == dia);
            string[] direccionSpliteada=direccion.Split('/');
            string lastDirection = direccionSpliteada[^1].Trim();
            var direccionExistente = await _context.Direccion.FirstOrDefaultAsync(d => d.NombreDireccion == lastDirection)
            ;
            
            
            await  _context.SaveChangesAsync();
            return Ok();
        }
        /*
        // DELETE: api/Visitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisita(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            _context.Visita.Remove(visita);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
  
    }
}

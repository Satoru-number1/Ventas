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
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Core.DTO;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreosController : ControllerBase
    {
        private readonly ICorreoRepositorio _context;

        public CorreosController(ICorreoRepositorio context)
        {
            _context = context;
        }

        // GET: api/Correos
        [HttpGet]
        public async Task<IActionResult> GetCorreo()
        {
            List<CorreoCIDTO> correos = await _context.GetCorreo();
            return Ok(correos);
        }   
        /*
        // GET: api/Correos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Correo>> GetCorreo(int id)
        {
            var correo = await _context.Correo.FindAsync(id);

            if (correo == null)
            {
                return NotFound();
            }

            return correo;
        }

        // PUT: api/Correos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorreo(int id, Correo correo)
        {
            if (id != correo.IdCorreo)
            {
                return BadRequest();
            }

            _context.Entry(correo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorreoExists(id))
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

        // POST: api/Correos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Correo>> PostCorreo(Correo correo)
        {
            _context.Correo.Add(correo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorreo", new { id = correo.IdCorreo }, correo);
        }

        // DELETE: api/Correos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorreo(int id)
        {
            var correo = await _context.Correo.FindAsync(id);
            if (correo == null)
            {
                return NotFound();
            }

            _context.Correo.Remove(correo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorreoExists(int id)
        {
            return _context.Correo.Any(e => e.IdCorreo == id);
        }*/
    }
}

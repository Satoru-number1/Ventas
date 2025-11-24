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
using MicroServicioVentas.Core.Interface;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {
        private readonly IPromocionRepositorio _context;

        public PromocionesController(IPromocionRepositorio context)
        {
            _context = context;
        }
        /*
        // GET: api/Promociones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromocion()
        {
            return await _context.Promocion.ToListAsync();
        }
        */
        // POST: api/Promociones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpGet("Promocion")]
        public async Task<IActionResult> GetPromociones()
        {
            return Ok(await _context.GetPromociones());
        }

        [HttpGet("Marketing/CampanaActual")]
        public async Task<IActionResult> GetCampanaActual()
        {

            return Ok(await _context.GetCampanaActual());
        }

        [HttpPost]
        public async Task<IActionResult> PostPromocion(PromocionDTO promocion)
        {
            return Ok(await _context.PostPromocion(promocion));

        }
        [HttpDelete("promocion/Eliminar")]
        public async Task<IActionResult> DeletePromocion( string codigoPromocion)
        {
            return Ok(await _context.DeletePromocion(codigoPromocion));
        }

        /*
        // GET: api/Promociones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocion>> GetPromocion(int id)
        {
            var promocion = await _context.Promocion.FindAsync(id);

            if (promocion == null)
            {
                return NotFound();
            }

            return promocion;
        }

        // PUT: api/Promociones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromocion(int id, Promocion promocion)
        {
            if (id != promocion.IdPromocion)
            {
                return BadRequest();
            }

            _context.Entry(promocion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionExists(id))
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
        *
        // POST: api/Promociones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPromocion(PromocionDTO promocion)
        {
            Promocion promo = new Promocion() { CodigoPromocion = promocion.CodigoPromocion,NombrePromocion=promocion.NombrePromocion
            , Descripcion=promocion.Descripcion,Descuento=promocion.Descuento,FechaInicio=promocion.FechaInicio,FechaFin=promocion.FechaFin};
            _context.Promocion.Add(promo);
            await _context.SaveChangesAsync();
            return Ok(promocion);

        }
        /*
        // DELETE: api/Promociones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocion(int id)
        {
            var promocion = await _context.Promocion.FindAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }

            _context.Promocion.Remove(promocion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocionExists(int id)
        {
            return _context.Promocion.Any(e => e.IdPromocion == id);
        }*/
    }
}

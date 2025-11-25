using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.VisualBasic;
using MicroServicioVentas.Core.Interface;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly IDireccionRepositorio _context;

        public DireccionesController(IDireccionRepositorio context)
        {
            _context = context;
        }

        // GET: api/Direcciones
        [HttpGet]
        public async Task<IActionResult> GetDireccion()
        {
            var dir=_context.GetDireccion();
            if (dir==null)
            {
                return NotFound();
            }
           
            return Ok(await dir);
        }

        // POST: api/Direcciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDireccion(string direccion,string codigoDireccion, decimal latitud, decimal longitud)
        {
            /*string[] subdivisiones=direccion.Split('/');
            for (int i=0;i<subdivisiones.Length;i++)
            {
                var nuevaDireccion = await (from d in _context.Direccion
                                            where d.NombreDireccion!=null
                                            select d).FirstOrDefaultAsync();
                if(nuevaDireccion==null || nuevaDireccion.NombreDireccion!=subdivisiones[i])
                {
                    var id_direccion = await (from d in _context.Direccion
                                              where d.NombreDireccion == subdivisiones[i-1]
                                              select d).FirstOrDefaultAsync();
                    Direccion dir = new Direccion
                    {
                        NombreDireccion = subdivisiones[i],
                        IdDependendiente = (id_direccion.IdDireccion<=0)?null:id_direccion.IdDireccion
                    }; 
                    _context.Direccion.Add(dir);
                    await _context.SaveChangesAsync();
                }
                
            }*/


            
            return Ok(await _context.PostDireccion(direccion,codigoDireccion,latitud,longitud ));
        }
/*
        // DELETE: api/Direcciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDireccion(int id)
        {
            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }

            _context.Direccion.Remove(direccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DireccionExists(int id)
        {
            return _context.Direccion.Any(e => e.IdDireccion == id);
        }*/
    }
}

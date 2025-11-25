using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // 1. Carga Eager (anticipada) para traer todos los datos necesarios:
            // Visita -> PedidoVisita -> Pedido -> Dirección
            var visitasConDatos = await _context.Visita

                // 1. Incluye la colección de la tabla de unión
                .Include(v => v.Pedidos)

                    // 2. Desde la unión, incluye la entidad Pedido
                    .ThenInclude(pv => pv.Pedido)

                        // 3. Desde el Pedido, incluye la entidad Dirección
                        // ¡Esto es crucial para obtener la DireccionCompleta del pedido!
                        .ThenInclude(p => p.Direccion)
                .ToListAsync();

            // 2. Proyección de la colección de entidades a la estructura de DTOs
            var rutasDto = visitasConDatos.Select(visita => new VisitaSucursalDOT
            {
                // Asignación de propiedades de la Visita (Ruta)
                CodigoRuta = visita.Direccion.CodigoDireccion, // Ejemplo, usando el ID como código
                Fecha =visita.FechaVisita, // Asumimos DateOnly en la entidad Visita

                // Mapeo de la lista de la tabla de unión al DTO PedidoDistribuidora
                PedidosDistribuidora = visita.Pedidos
                    .Select(pv => new PedidoDistribuidora
                    {
                        // Asignación de propiedades del Pedido
                        CodigoPedido = pv.Pedido.CodigoPedido,
                        Estado = pv.Pedido.Estado,

                        // ⭐ Aquí tomamos la DireccionCompleta del Pedido.Direccion
                        DireccionEnvio = pv.Pedido.Direccion.DireccionCompleta,

                        FechaEntrega = pv.Pedido.FechaPedido
                    })
                    .ToList()
            }).ToList();

            if (rutasDto == null || !rutasDto.Any())
            {
                return NotFound("No se encontraron rutas programadas.");
            }

            return Ok(rutasDto);
        }


        [HttpGet("Ruta/Codigo/{codigoDireccion}")]
        public async Task<IActionResult> GetRuta([FromRoute]string codigoDireccion)
        {
            var direccionFiltro = await _context.Direccion
            .FirstOrDefaultAsync(d => d.CodigoDireccion == codigoDireccion);

            if (direccionFiltro == null)
            {
                return NotFound($"No se encontró una Dirección con el código '{codigoDireccion}'.");
            }

            // 2. Cargar Visitas (Paradas) asociadas a esa IdDireccion
            var visitasConDatos = await _context.Visita
                // Filtramos solo las visitas que usan la IdDireccion encontrada
                .Where(v => v.IdDireccion == direccionFiltro.IdDireccion)

                // 3. Carga Eager (anticipada) para traer todos los datos de los pedidos
                .Include(v => v.Direccion) // Incluimos la dirección de la visita (que es la dirección de entrega)
                .Include(v => v.Pedidos)
                    .ThenInclude(pv => pv.Pedido)
                        .ThenInclude(p => p.Direccion) // Incluimos la dirección del pedido (por si acaso, aunque ya debería ser la misma)
                .ToListAsync();

            // 4. Proyección a DTOs (Usando tu método de extensión)
            var rutasDto = visitasConDatos
                .Select(v => v.toVisitaSucursalDTO())
                .ToList();

            if (!rutasDto.Any())
            {
                return NotFound($"No se encontraron rutas programadas para el código: '{codigoDireccion}'.");
            }

            return Ok(rutasDto);
         
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
        /*[HttpPost]
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
        }*/
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

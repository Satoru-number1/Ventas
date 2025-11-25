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
using MicroServicioVentas.Core.Interface;

namespace MicroServicioVentas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _context;

        public ClientesController(IClienteRepositorio context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetCliente()
        {
            var cliente = await _context.GetCLiente();
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> PostCliente(string ci, string nombre, string apellidop, string apellidom, string correo)
        {


            return Ok(await _context.PostCliente(ci, nombre, apellidop, apellidom, correo));
        }
      
            // GET: api/Clientes
            /* [HttpGet]
             public async Task<IActionResult> GetCliente()
             {
                 //carga los correos relacionados
                 var cliente = await _context.Cliente.Include(c => c.Correos).ToListAsync();
                 var clienteDTO= cliente.Select(c=>c.toClienteDTO()).ToList();
                 return Ok(clienteDTO);
             }

             // GET: api/Clientes/5
             [HttpGet("{id}")]
             public async Task<ActionResult<Cliente>> GetCliente(int id)
             {
                 var cliente = await _context.Cliente.FindAsync(id);

                 if (cliente == null)
                 {
                     return NotFound();
                 }

                 return cliente;
             }

             // PUT: api/Clientes/5
             // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
             [HttpPut("{id}")]
             public async Task<IActionResult> PutCliente(int id, Cliente cliente)
             {
                 if (id != cliente.IdCliente)
                 {
                     return BadRequest();
                 }

                 _context.Entry(cliente).State = EntityState.Modified;

                 try
                 {
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!ClienteExists(id))
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

             // POST: api/Clientes
             // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
             [HttpPost]
             public async Task<IActionResult> PostCliente(string ci,string nombre,string apellidop,string apellidom,string correo)
             {
                 //como ya esta inicializado los correos como vacio
                 Cliente cliente=new Cliente() { Ci=ci,Nombre=nombre,ApellidoMaterno=apellidom,ApellidoPaterno=apellidop};

                 Correo ecorreo = new Correo() { CorreoElectronico = correo };
                 cliente.Correos.Add(ecorreo);
                 _context.Cliente.Add(cliente);
                 await _context.SaveChangesAsync();
                 var clienteDTO=cliente.toClienteDTO();
                 return Ok(clienteDTO);
             }

             // DELETE: api/Clientes/5
             [HttpDelete("{id}")]
             public async Task<IActionResult> DeleteCliente(int id)
             {
                 var cliente = await _context.Cliente.FindAsync(id);
                 if (cliente == null)
                 {
                     return NotFound();
                 }

                 _context.Cliente.Remove(cliente);
                 await _context.SaveChangesAsync();

                 return NoContent();
             }

             private bool ClienteExists(int id)
             {
                 return _context.Cliente.Any(e => e.IdCliente == id);
             }*/
        }
}

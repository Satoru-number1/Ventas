using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroServicioVentas.Infraestructure.Repositorio
{
    public class ClienteRepositorio: IClienteRepositorio
    {
        private readonly MicroServicioVentasContext _context;
        public ClienteRepositorio(MicroServicioVentasContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteDTO>> GetCLiente()
        {
            //carga los correos relacionados
            var cliente = await _context.Cliente.Include(c => c.Correos).ToListAsync();
            var clienteDTO = cliente.Select(c => c.toClienteDTO()).ToList();
            return clienteDTO;
        }

        public async Task<ClienteDTO> PostCliente(string ci, string nombre, string apellidop, string apellidom, string correo)
        {
            //como ya esta inicializado los correos como vacio
            Cliente cliente = new Cliente() { Ci = ci, Nombre = nombre, ApellidoMaterno = apellidom, ApellidoPaterno = apellidop };

            Correo ecorreo = new Correo() { CorreoElectronico = correo };
            cliente.Correos.Add(ecorreo);
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            var clienteDTO = cliente.toClienteDTO();
            return clienteDTO;
        }

    }
}

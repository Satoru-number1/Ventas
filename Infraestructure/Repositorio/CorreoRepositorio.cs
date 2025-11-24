using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroServicioVentas.Infraestructure.Repositorio
{
    public class CorreoRepositorio: ICorreoRepositorio
    {
        private readonly MicroServicioVentasContext _context;
        public CorreoRepositorio(MicroServicioVentasContext context)
        {
            _context = context;
        }

        public async Task<List<CorreoCIDTO>> GetCorreo()
        {
            //uso el include para cargar la entidad relacionada Cliente
            var cliente = await _context.Correo.Include(c => c.Cliente).ToListAsync();
            //mapear a CorreoCiDTO para que no cause una referencia circular
            var correoCiDTO = cliente.Select(c => c.toCorreoCIDTO()).ToList();
            return correoCiDTO;
        }
    }
}

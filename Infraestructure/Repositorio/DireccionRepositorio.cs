using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace MicroServicioVentas.Infraestructure.Repositorio
{
    public class DireccionRepositorio : IDireccionRepositorio
    {
        private readonly MicroServicioVentasContext _context;
        public DireccionRepositorio(MicroServicioVentasContext context)
        {
            _context = context;
        }

        public async Task<List<DireccionDTO>> GetDireccion()
        {

            var direcciones = await _context.Direccion.Include(d => d.Pais).ToListAsync();

            return  direcciones.Select(d=>d.toDireccionDTO()).ToList();
        }

        public async Task<IActionResult> PostDireccion(string direccion,decimal latitud,decimal longitud)
        {
            var paisBolivia = await _context.Pais
                .FirstOrDefaultAsync(p => p.NombrePais.ToLower() == "bolivia");

            if (paisBolivia == null)
            {
                return new BadRequestObjectResult("El pais 'Bolivia' no se encontro en la base de datos.");
            }

            int idPais = paisBolivia.IdPais;
            string[] subdivisiones = direccion.Split('/');
            int? idPadreActual = null;

            //Procesa la cadena de direcciones
            for (int i = 0; i < subdivisiones.Length; i++)
            {
                string nombreActual = subdivisiones[i].Trim();

                // busqueda de la dirección existente del padre actual
                var direccionExistente = await _context.Direccion
                    .FirstOrDefaultAsync(d => d.NombreDireccion == nombreActual &&
                                              d.IdDependiente == idPadreActual);

                if (direccionExistente != null)
                {
                    idPadreActual = direccionExistente.IdDireccion;
                }
                else
                {
                    
                    Direccion dir = new Direccion()
                    {
                        IdPais = idPais, 
                        NombreDireccion = nombreActual,
                        IdDependiente = idPadreActual,
                        DireccionCompleta = direccion,
                        Latitud = latitud,
                        Longitud = longitud
                    };

                    _context.Direccion.Add(dir);

                    //se actualiza el id del padre actual
                    idPadreActual = dir.IdDireccion;
                }
            }
                    await _context.SaveChangesAsync();


            return new OkObjectResult("Direccion registrada correctamente.");
        }


    }
}

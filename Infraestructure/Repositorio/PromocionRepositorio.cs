using MicroServicioVentas.Core.DTO;
using MicroServicioVentas.Core.Entity;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Core.Mapeadores;
using MicroServicioVentas.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroServicioVentas.Infraestructure.Repositorio
{
    public class PromocionRepositorio:IPromocionRepositorio
    {

        private readonly MicroServicioVentasContext _context;
        public PromocionRepositorio(MicroServicioVentasContext context)
        {
            _context = context;
        }


        public async Task<List<CampanaDTO>> GetCampanaActual()

        {
            // Usamos DateTime.UtcNow para asegurar la comparación correcta con PostgreSQL.
            var fechaHoyUtc = DateTime.UtcNow;

/*            // 1. Buscar promociones activas
            var campanasActivas = await _context.Promocion
                // Filtra todas las promociones donde:
                // A) La fecha de inicio es anterior o igual a hoy (ya empezó)
                // Y
                // B) La fecha de fin es posterior o igual a hoy (aún no termina)
                .Where(p => p.FechaInicio <= fechaHoyUtc && p.FechaFin >= fechaHoyUtc)
                .Select(p => new CampanaDTO // 2. Mapear a DTO
                {
                    CodigoPromocion = p.CodigoPromocion,
                    Descripcion = p.Descripcion,
                    FechaFin = p.FechaFin // La fecha de fin es útil para el marketing
                })
                .ToListAsync();
            */
           
            return new List<CampanaDTO> ();
        }
        public async Task<List<PromocionDTO>> GetPromociones()
        {
            var promociones = await (from p in _context.Promocion
                                     where p.Estado != "Desactivado" && p.Estado != null
                                    select p).Select(p => p.toPromocionDTO()).ToListAsync();
            

            return promociones;
        }
        public async Task<PromocionDTO> PostPromocion(PromocionDTO promocion)
        {
            Promocion promo = new Promocion()
            {
                CodigoPromocion = promocion.CodigoPromocion,
                NombrePromocion = promocion.NombrePromocion,
                Descuento = promocion.Descuento,
                Descripcion = promocion.Descripcion,
                FechaInicio = promocion.FechaInicio,
                FechaFin = promocion.FechaFin
            };
            _context.Promocion.Add(promo);

            await _context.SaveChangesAsync();
            var res=promo.toPromocionDTO();
            return ( res);
        }
        public async Task<IActionResult> DeletePromocion(string codigoPromocion)
        {
            var promocion = await _context.Promocion.FirstOrDefaultAsync(p => p.CodigoPromocion == codigoPromocion);
            if (promocion == null)
            {
                return new NotFoundResult();
            }
            promocion.Estado = "Desactivado";
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}

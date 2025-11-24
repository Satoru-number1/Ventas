using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MicroServicioVentas.Core.Entity;

namespace MicroServicioVentas.Infraestructure.Data
{
    public class MicroServicioVentasContext : DbContext
    {
        public MicroServicioVentasContext (DbContextOptions<MicroServicioVentasContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Correo> Correo { get; set; } = default!;
        public DbSet<Pedido> Pedido { get; set; } = default!;
        public DbSet<Venta> Venta { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Promocion> Promocion { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Producto> Producto { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Direccion> Direccion { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Pais> Pais { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.DetallePedido> DetallePedido { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Visita> Visita { get; set; } = default!;
        public DbSet<MicroServicioVentas.Core.Entity.Semana> Semana { get; set; } = default!;
    }
}

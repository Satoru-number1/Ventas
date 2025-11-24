using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroServicioVentas.Infraestructure.Data;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Infraestructure.Repositorio;
var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddDbContext<MicroServicioVentasContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("MicroServicioVentasContext") ?? throw new InvalidOperationException("Connection string 'MicroServicioVentasContext' not found.")));
//var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
//                       ?? builder.Configuration.GetConnectionString("MicroServicioVentasContext");
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                         ?? builder.Configuration.GetConnectionString("MicroServicioVentasContext");

// Verificar si la cadena de conexión se encontró.
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'MicroServicioVentasContext' or 'DATABASE_URL' not found.");
}

// ?? SOLUCIÓN AL ERROR: REGISTRAR EL DB CONTEXT
// Asumo que estás usando Npgsql (PostgreSQL) basado en el código comentado.
builder.Services.AddDbContext<MicroServicioVentasContext>(options =>
{
    // Asegúrate de que tienes instalado el paquete Npgsql.EntityFrameworkCore.PostgreSQL
    options.UseNpgsql(connectionString);
});



// Add services to the container.

builder.WebHost.UseUrls("http://0.0.0.8080");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ICorreoRepositorio, CorreoRepositorio>();
builder.Services.AddScoped<IDireccionRepositorio, DireccionRepositorio>();
builder.Services.AddScoped<IPromocionRepositorio, PromocionRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio,PedidoRepositorio>();


builder.Services.AddCors(option =>
{
    option.AddPolicy("myApp", policyBuilder =>
    {

        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});

var app = builder.Build();


using (var scope =app.Services.CreateScope())
{
    var db=scope.ServiceProvider.GetRequiredService<MicroServicioVentasContext>();
    db.Database.Migrate();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("myApp");

app.UseAuthorization();

app.MapControllers();

app.Run();

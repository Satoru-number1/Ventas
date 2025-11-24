using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroServicioVentas.Infraestructure.Data;
using MicroServicioVentas.Core.Interface;
using MicroServicioVentas.Infraestructure.Repositorio;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MicroServicioVentasContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MicroServicioVentasContext") ?? throw new InvalidOperationException("Connection string 'MicroServicioVentasContext' not found.")));



// Add services to the container.

builder.WebHost.UseUrls("http://0.0.0.8080")

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myApp");

app.UseAuthorization();

app.MapControllers();

app.Run();

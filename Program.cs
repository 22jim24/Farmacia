using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Middlewares;
using Farmaco.Repositorios;
using Farmaco.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios (aquí irá la inyección de dependencias)
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opciones =>
    {
        opciones.InvalidModelStateResponseFactory = contexto =>
        {
            // SelectMany aplana los errores de validación de los DTOs en una sola lista
            List<string> errores = contexto.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            ErrorResponse respuesta = new(400, string.Join(" | ", errores));
            return new BadRequestObjectResult(respuesta);
        };
    });

builder.Services.AddOpenApi();

// Inyección de dependencias
builder.Services.AddSingleton<IReCliente, ReClienteRam>();
builder.Services.AddScoped<ServicioCliente>();

builder.Services.AddSingleton<IReEmpleado, ReEmpleadoRam>();
builder.Services.AddScoped<ServicioEmpleados>();

builder.Services.AddSingleton<IReProducto, ReProductoRam>();
builder.Services.AddScoped<ServicioProductos>();

builder.Services.AddSingleton<IReProveedor, ReProveedorRam>();
builder.Services.AddScoped<ServicioProveedores>();

builder.Services.AddSingleton<IReVenta, ReVentaRam>();
builder.Services.AddScoped<ServicioVentas>();

var app = builder.Build();

app.UseMiddleware<ManejoErroresMiddleware>();

// Configurar cómo se atienden las peticiones
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Encender la API
app.Run();
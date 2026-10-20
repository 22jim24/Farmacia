using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Servicios;

namespace Farmaco.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VentasController(ServicioVentas servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Ventas>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{NombreCliente}")]
    public ActionResult<Ventas> BuscarPorCliente(string NombreCliente)
    {
        Ventas? venta = servicio.BuscarPorCliente(NombreCliente);
        if (venta == null)
        {
            return NotFound($"No existe una venta con nombre de cliente {NombreCliente}");
        }
        return Ok(venta);
    }
    
    [HttpGet("metodo-pago/{metodo}")]
    public ActionResult<List<Ventas>> ListarPorMetodoPago(string metodo)
    {
        return Ok(servicio.ListarPorMetodoPago(metodo));
    }

    [HttpPost]
    public ActionResult<Ventas> Crear(CreateVenta request)
    {
        Ventas nueva = servicio.Crear(request);
        return Created($"/api/ventas/{nueva.NombreCliente}", nueva);
    }

    [HttpPut("{NombreCliente}")]
    public ActionResult<Ventas> Actualizar(string NombreCliente, UpdateVenta request)
    {
        Ventas? actualizado = servicio.Actualizar(NombreCliente, request);
        if (actualizado == null)
        {
            return NotFound($"No existe una venta con nombre de cliente {NombreCliente}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{NombreCliente}")]
    public IActionResult Eliminar(string NombreCliente)
    {
        servicio.Eliminar(NombreCliente);
        return Ok("Venta eliminada correctamente.");
    }
}
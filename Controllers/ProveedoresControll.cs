using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Servicios;

namespace Farmaco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController(ServicioProveedores servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Proovedor>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{nombreProveedor}")]
    public ActionResult<Proovedor> BuscarPorNombre(string nombreProveedor)
    {
        Proovedor? proveedor = servicio.BuscarPorNombre(nombreProveedor);
        if (proveedor == null)
        {
            return NotFound($"No existe un proveedor con nombre {nombreProveedor}");
        }
        return Ok(proveedor);
    }
    
    [HttpPost]
    public ActionResult<Proovedor> Crear(CreateProveedor request)
    {
        Proovedor nuevo = servicio.Crear(request);
        return Created($"/api/proveedores/{nuevo.NombreProveedor}", nuevo);
    }

    [HttpPut("{nombreProveedor}")]
    public ActionResult<Proovedor> Actualizar(string nombreProveedor, UpdateProveedor request)
    {
        Proovedor? actualizado = servicio.Actualizar(nombreProveedor, request);
        if (actualizado == null)
        {
            return NotFound($"No existe un proveedor con nombre {nombreProveedor}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{nombreProveedor}")]
    public IActionResult Eliminar(string nombreProveedor)
    {
        servicio.Eliminar(nombreProveedor);
        return Ok("Proveedor eliminado correctamente.");
    }
}
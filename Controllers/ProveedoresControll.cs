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
        if (servicio.ExisteProveedor(request.NombreProveedor))
        {
            return Conflict($"Ya existe un proveedor con nombre {request.NombreProveedor}");
        }

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
        if (servicio.ExisteProveedor(nombreProveedor) == false)
        {
            return NotFound($"No existe un proveedor con nombre {nombreProveedor}");
        }

        bool eliminado = servicio.Eliminar(nombreProveedor);
        if (eliminado == false)
        {
            return NotFound($"No se pudo eliminar el proveedor con nombre {nombreProveedor}");
        }

        return NoContent();
    }
}
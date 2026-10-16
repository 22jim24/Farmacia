using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Servicios;

namespace Farmaco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(ServicioCliente servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Cliente>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{dni}")]
    public ActionResult<Cliente> BuscarPorDni(string dni)
    {
        Cliente? cliente = servicio.BuscarPorDni(dni);
        if (cliente == null)
        {
            return NotFound($"No existe un cliente con DNI {dni}");
        }
        return Ok(cliente);
    }
    
    [HttpPost]
    public ActionResult<Cliente> Crear(CreateCliente request)
    {
        if (servicio.ExisteDni(request.Dni))
        {
            return Conflict($"Ya existe un cliente con DNI {request.Dni}");
        }

        Cliente nuevo = servicio.Crear(request);
        return Created($"/api/clientes/{nuevo.Dni}", nuevo);
    }

    [HttpPut("{dni}")]
    public ActionResult<Cliente> Actualizar(string dni, UpdateCliente request)
    {
        Cliente? actualizado = servicio.Actualizar(dni, request);
        if (actualizado == null)
        {
            return NotFound($"No existe un cliente con DNI {dni}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{dni}")]
    public IActionResult Eliminar(string dni)
    {
        if (servicio.ExisteDni(dni) == false)
        {
            return NotFound($"No existe un cliente con DNI {dni}");
        }

        bool eliminado = servicio.Eliminar(dni);
        if (eliminado == false)
        {
            return NotFound($"No existe un cliente con DNI {dni}");
        }

        return NoContent();
    }
}

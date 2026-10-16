using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Servicios;


namespace Farmaco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadosController(ServicioEmpleados servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Empleado>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{dni}")]
    public ActionResult<Empleado> BuscarPorDni(string dni)
    {
        Empleado? empleado = servicio.BuscarPorDni(dni);
        if (empleado == null)
        {
            return NotFound($"No existe un empleado con DNI {dni}");
        }
        return Ok(empleado);
    }

    [HttpPost]
    public ActionResult<Empleado> Crear(CreateEmpleado request)
    {
        if (servicio.ExisteDni(request.Dni))
        {
            return Conflict($"Ya existe un empleado con DNI {request.Dni}");
        }

        if (servicio.CargoEsValido(request.Cargo)== false)
        {
            return BadRequest($"El cargo {request.Cargo} no es válido");
        }

        Empleado nuevo = servicio.Crear(request);
        return Created($"/api/empleados/{nuevo.Dni}", nuevo);
    }

    [HttpPut("{dni}")]
    public ActionResult<Empleado> Actualizar(string dni, UpdateEmpleado request)
    {
        if (servicio.CargoEsValido(request.Cargo)== false)
        {
            return BadRequest($"El cargo {request.Cargo} no es válido");
        }

        Empleado? actualizado = servicio.Actualizar(dni, request);
        if (actualizado == null)
        {
            return NotFound($"No existe un empleado con DNI {dni}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{dni}")]
    public IActionResult Eliminar(string dni)
    {
        if (servicio.ExisteDni(dni) == false)
        {
            return NotFound($"No existe un empleado con DNI {dni}");
        }

        bool eliminado = servicio.Eliminar(dni);
        if (eliminado == false)
        {
            return NotFound($"No se pudo eliminar el empleado con DNI {dni}");
        }

        return NoContent();
    }
}
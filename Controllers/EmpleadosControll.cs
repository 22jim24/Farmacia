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

    [HttpGet("cargo/{cargo}")]
    public ActionResult<List<Empleado>> ListarPorCargo(string cargo)
    {
        return Ok(servicio.ListarPorCargo(cargo));
    }

    [HttpPost]
    public ActionResult<Empleado> Crear(CreateEmpleado request)
    {
        Empleado nuevo = servicio.Crear(request);
        return Created($"/api/empleados/{nuevo.Dni}", nuevo);
    }

    [HttpPut("{dni}")]
    public ActionResult<Empleado> Actualizar(string dni, UpdateEmpleado request)
    {
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
        servicio.Eliminar(dni);
        return Ok("Empleado eliminado correctamente.");
    }
}
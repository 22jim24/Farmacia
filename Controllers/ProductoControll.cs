using Microsoft.AspNetCore.Mvc;
using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Servicios;

namespace Farmaco.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController(ServicioProductos servicio) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Producto>> ListarTodos()
    {
        return Ok(servicio.ListarTodos());
    }

    [HttpGet("{nombre}")]
    public ActionResult<Producto> BuscarPorNombre(string nombre)
    {
        Producto? producto = servicio.BuscarPorNombre(nombre);
        if (producto == null)
        {
            return NotFound($"No existe un producto con nombre {nombre}");
        }
        return Ok(producto);
    }
    
    [HttpPost]
    public ActionResult<Producto> Crear(CreateProducto request)
    {
        Producto nuevo = servicio.Crear(request);
        return Created($"/api/productos/{nuevo.Nombre}", nuevo);
    }

    [HttpPut("{nombre}")]
    public ActionResult<Producto> Actualizar(string nombre, UpdateProducto request)
    {
        Producto? actualizado = servicio.Actualizar(nombre, request);
        if (actualizado == null)
        {
            return NotFound($"No existe un producto con nombre {nombre}");
        }

        return Ok(actualizado);
    }

    [HttpDelete("{nombre}")]
    public IActionResult Eliminar(string nombre)
    {
        if (servicio.ExisteProducto(nombre) == false)
        {
            return NotFound($"No existe un producto con nombre {nombre}");
        }

        bool eliminado = servicio.Eliminar(nombre);
        if (eliminado == false)
        {
            return NotFound($"No se pudo eliminar el producto con nombre {nombre}");
        }

        return NoContent();
    }
}
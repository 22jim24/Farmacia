using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;

namespace Farmaco.Servicios;

public class ServicioProductos(IReProducto repositorio)
{
    public List<Producto> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Producto? BuscarPorNombre(string nombre)
    {
        return repositorio.BuscarPorNombre(nombre);
    }

    public List<Producto> ListarStockBajo()
    {
        return repositorio.ListarTodos().Where(p => p.Stock <= 5).ToList();
    }

    public decimal CalcularValorInventario()
    {
        List<Producto> todos = repositorio.ListarTodos();
        if (todos.Count == 0)
        {
            return 0;
        }
        return todos.Sum(p => p.Precio * p.Stock);
    }

    public bool DatosSonValidos(decimal precio, int stock)
    {
        return precio >= 0 && stock >= 0;
    }

    public bool ExisteProducto(string nombre)
    {
        return repositorio.BuscarPorNombre(nombre) != null;
    }

    public Producto Crear(CreateProducto request)
    {
        Producto nuevo = new(request.Nombre, request.Precio ?? 0, request.Stock ?? 0);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Producto? Actualizar(string nombre, UpdateProducto request)
    {
        Producto? producto = repositorio.BuscarPorNombre(nombre);
        if (producto == null)
        {
            return null;
        }
        producto.ActualizarNombre(request.Nombre);
        producto.ActualizarPrecio(request.Precio ?? 0);
        producto.ActualizarStock(request.Stock ?? 0);
        return producto;
    }

    public bool Eliminar(string nombre)
    {
        return repositorio.EliminarPorNombre(nombre);
    }
}
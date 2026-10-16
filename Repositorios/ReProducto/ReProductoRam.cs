using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public class ReProductoRam : IReProducto
{
    private readonly List<Producto> productos =
    [
        new("Paracetamol", 2.50m, 100),
        new("Ibuprofeno", 3.00m, 80),
        new("Amoxicilina", 8.50m, 40),
        new("Iblino", 15.00m, 4)
    ];

    public void Agregar(Producto producto)
    {
        productos.Add(producto);
    }

    public Producto? BuscarPorNombre(string nombre)
    {
        return productos.FirstOrDefault(p => p.Nombre == nombre);
    }

    public List<Producto> ListarTodos()
    {
        return productos;
    }

    public bool EliminarPorNombre(string nombre)
    {
        Producto? producto = BuscarPorNombre(nombre);
        if (producto == null)
        {
            return false;
        }
        productos.Remove(producto);
        return true;
    }
}
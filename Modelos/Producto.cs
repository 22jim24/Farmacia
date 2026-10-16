namespace Farmaco.Modelos;

public class Producto
{
    public string Nombre { get; private set; } = string.Empty;
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }

    public Producto(string nombre, decimal precio, int stock)
    {
        if (precio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }

        if (stock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }

        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public void ActualizarNombre(string nuevoNombre)
    {
        Nombre = nuevoNombre;
    }
    public void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Precio = nuevoPrecio;
    }

    public void ActualizarStock(int nuevoStock)
    {
        if (nuevoStock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }
        Stock = nuevoStock;
    }
}
using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public class ReVentaRam : IReVenta
{
    private readonly List<Ventas> ventas =
    [
        new("Ana Torres", "Paracetamol 500mg", 2, 2.50m, "YAPE_PLIN", 5.00m),
        new("Luis Ramos", "Ibuprofeno 400mg", 3, 3.00m, "EFECTIVO", 9.00m),
        new("Sofía Paredes", "Jarabe Panadol", 1, 15.00m, "TARJETA", 15.00m),
        new("Marco Díaz", "Amoxicilina 500mg", 2, 8.50m, "TRANSFERENCIA", 17.00m)
    ];

    public void Agregar(Ventas venta)
    {
        ventas.Add(venta);
    }

    public Ventas? BuscarPorCliente(string nombreCliente)
    {
        return ventas.FirstOrDefault(v => v.NombreCliente == nombreCliente);
    }

    public List<Ventas> ListarTodos()
    {
        return ventas;
    }

    public bool EliminarPorCliente(string nombreCliente)
    {
        Ventas? venta = BuscarPorCliente(nombreCliente);
        if (venta == null)
        {
            return false;
        }
        ventas.Remove(venta);
        return true;
    }
}
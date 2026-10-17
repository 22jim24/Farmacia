using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;

namespace Farmaco.Servicios;

public class ServicioVentas(IReVenta repositorio)
{
    public List<Ventas> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Ventas? BuscarPorCliente(string nombreCliente)
    {
        return repositorio.BuscarPorCliente(nombreCliente);
    }

    public List<Ventas> ListarPorMetodoPago(string metodoPago)
    {
        return repositorio.ListarTodos().Where(v => v.MetodoPago == metodoPago).ToList();
    }

    public decimal CalcularTotalIngresos()
    {
        List<Ventas> todas = repositorio.ListarTodos();
        if (todas.Count == 0)
        {
            return 0;
        }
        return todas.Sum(v => v.Total);
    }

    public bool MetodoPagoEsValido(string metodo)
    {
        return metodo == "EFECTIVO" || metodo == "TARJETA" || metodo == "YAPE_PLIN" || metodo == "TRANSFERENCIA";
    }

    public bool DatosSonValidos(int cantidad, decimal precio)
    {
        return cantidad > 0 && precio >= 0;
    }

    public Ventas Crear(CreateVenta request)
    {
        decimal totalCalculado = (request.Cantidad ?? 0) * (request.Precio ?? 0);
        Ventas nueva = new(request.NombreCliente, request.NombreProducto, request.Cantidad ?? 0, request.Precio ?? 0, request.MetodoPago, totalCalculado);
        repositorio.Agregar(nueva);
        return nueva;
    }

    public bool ExisteVenta(string nombreCliente)
    {
        return repositorio.BuscarPorCliente(nombreCliente) != null;
    }
    public Ventas? Actualizar(string nombreCliente, UpdateVenta request)
    {
        Ventas? venta = repositorio.BuscarPorCliente(nombreCliente);
        if (venta == null)
        {
            return null;
        }

        venta.CambiarNombreCliente(request.NombreCliente);
        venta.CambiarNombreProducto(request.NombreProducto);
        venta.CambiarCantidad(request.Cantidad ?? 0);
        venta.CambiarPrecio(request.Precio ?? 0);
        venta.CambiarMetodoPago(request.MetodoPago);
        venta.RecalcularTotal();
        return venta;
    }

    public bool Eliminar(string NombreCliente)
    {   
        return repositorio.EliminarPorCliente(NombreCliente);
    }
}
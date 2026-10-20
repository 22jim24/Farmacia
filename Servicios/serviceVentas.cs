using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;
using Farmaco.Excepciones;

namespace Farmaco.Servicios;

public class ServicioVentas(IReVenta repositorio)
{
    public List<Ventas> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Ventas BuscarPorCliente(string nombreCliente)
    {
        Ventas? venta = repositorio.BuscarPorCliente(nombreCliente) ?? throw new RecursoNoEncontradoException($"No existe una venta del cliente {nombreCliente}");
        return venta;
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
        if (repositorio.BuscarPorCliente(request.NombreCliente) != null)
        {
            throw new ConflictoException($"Ya existe una venta del cliente {request.NombreCliente}");
        }

        decimal totalCalculado = (request.Cantidad ?? 0) * (request.Precio ?? 0);
        Ventas nueva = new(request.NombreCliente, request.NombreProducto, request.Cantidad ?? 0, request.Precio ?? 0, request.MetodoPago, totalCalculado);
        repositorio.Agregar(nueva);
        return nueva;
    }

    public bool ExisteVenta(string nombreCliente)
    {
        return repositorio.BuscarPorCliente(nombreCliente) != null;
    }
    public Ventas Actualizar(string nombreCliente, UpdateVenta request)
    {
        Ventas venta = BuscarPorCliente(nombreCliente);
        venta.CambiarNombreCliente(request.NombreCliente);
        venta.CambiarNombreProducto(request.NombreProducto);
        venta.CambiarCantidad(request.Cantidad ?? 0);
        venta.CambiarPrecio(request.Precio ?? 0);
        venta.CambiarMetodoPago(request.MetodoPago);
        venta.RecalcularTotal();
        return venta;
    }

    public void Eliminar(string NombreCliente)
    {
        bool eliminado = repositorio.EliminarPorCliente(NombreCliente);
        if (eliminado == false)
        {
            throw new RecursoNoEncontradoException($"No existe una venta con nombre de cliente {NombreCliente}");
        }
    }
}
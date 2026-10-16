
using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public interface IReVenta
{
    void Agregar(Ventas venta);
    Ventas? BuscarPorCliente(string nombreCliente);
    List<Ventas> ListarTodos();
    bool EliminarPorCliente(string nombreCliente);
}
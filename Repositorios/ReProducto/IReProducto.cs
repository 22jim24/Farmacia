using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public interface IReProducto
{
    void Agregar(Producto producto);
    Producto? BuscarPorNombre(string nombre);
    List<Producto> ListarTodos();
    bool EliminarPorNombre(string nombre);
}
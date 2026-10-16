using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public interface IReProveedor
{
    void Agregar(Proovedor proveedor);
    Proovedor? BuscarPorNombre(string nombreProveedor);
    List<Proovedor> ListarTodos();
    bool EliminarPorNombre(string nombreProveedor);
}
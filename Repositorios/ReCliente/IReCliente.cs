using Farmaco.Modelos;

namespace Farmaco.Repositorios;
public interface IReCliente
{
    void Agregar(Cliente cliente);
    Cliente? BuscarPorDni(string dni);
    List<Cliente> ListarTodos();
    bool EliminarPorDni(string dni);

}
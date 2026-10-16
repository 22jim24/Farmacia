using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public interface IReEmpleado
{
    void Agregar(Empleado empleado);
    Empleado? BuscarPorDni(string dni);
    List<Empleado> ListarTodos();
    bool EliminarPorDni(string dni);
}
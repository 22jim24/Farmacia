using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;

namespace Farmaco.Servicios;

public class ServicioEmpleados(IReEmpleado repositorio)
{
    public List<Empleado> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Empleado? BuscarPorDni(string dni)
    {
        return repositorio.BuscarPorDni(dni);
    }

    public List<Empleado> ListarPorCargo(string cargo)
    {
        return repositorio.ListarTodos().Where(e => e.Cargo == cargo).ToList();
    }

    public bool CargoEsValido(string cargo)
    {
        return cargo == "ADMIN" || cargo == "FARMACEUTICO" || cargo == "CAJERO" || cargo == "ALMACENERO";
    }

    public bool ExisteDni(string dni)
    {
        return repositorio.BuscarPorDni(dni) != null;
    }

    public Empleado Crear(CreateEmpleado request)
    {
        Empleado nuevo = new(request.Dni, request.Nombre, request.Apellido, request.Correo, request.Telefono, request.Cargo);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Empleado? Actualizar(string dni, UpdateEmpleado request)
    {
        Empleado? empleado = repositorio.BuscarPorDni(dni);
        if (empleado == null)
        {
            return null;
        }

        empleado.Nombre = request.Nombre;
        empleado.Apellido = request.Apellido;
        empleado.Correo = request.Correo;
        empleado.Telefono = request.Telefono;
        empleado.CambiarCargo(request.Cargo);
        return empleado;
    }

    public bool Eliminar(string dni)
    {
        return repositorio.EliminarPorDni(dni);
    }
}
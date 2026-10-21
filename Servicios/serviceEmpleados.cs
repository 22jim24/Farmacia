using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;
using Farmaco.Excepciones;

namespace Farmaco.Servicios;

public class ServicioEmpleados(IReEmpleado repositorio)
{
    public List<Empleado> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Empleado BuscarPorDni(string dni)
    {
        Empleado? empleado = repositorio.BuscarPorDni(dni) 
            ?? throw new RecursoNoEncontradoException($"No existe un empleado con DNI {dni}");
        return empleado;
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
        if (repositorio.BuscarPorDni(request.Dni) != null)
        {
            throw new ConflictoException($"Ya existe un empleado con DNI {request.Dni}");
        }

        Empleado nuevo = new(request.Dni, request.Nombre, request.Apellido, request.Correo, request.Telefono, request.Cargo);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Empleado Actualizar(string dni, UpdateEmpleado request)
    {
        Empleado empleado = BuscarPorDni(dni);
        empleado.Nombre = request.Nombre;
        empleado.Apellido = request.Apellido;
        empleado.Correo = request.Correo;
        empleado.Telefono = request.Telefono;
        empleado.CambiarCargo(request.Cargo);
        return empleado;
    }

    public void Eliminar(string dni)
    {
        bool eliminado = repositorio.EliminarPorDni(dni);
        if (eliminado == false)
        {
            throw new RecursoNoEncontradoException($"No existe un empleado con DNI {dni}");
        }
    }
}
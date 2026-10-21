using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;
using Farmaco.Excepciones;

namespace Farmaco.Servicios;

public class ServicioCliente(IReCliente repositorio)
{
    public List<Cliente> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Cliente BuscarPorDni(string dni)
    {
        Cliente? cliente = repositorio.BuscarPorDni(dni) 
            ?? throw new RecursoNoEncontradoException($"No existe un cliente con DNI {dni}");
        return cliente;
    }

    public List<Cliente> ListarClientesFrecuentes()
    {
        return repositorio.ListarTodos().Where(c => c.PuntosConseguidos >= 100).ToList();
    }

    public double CalcularPromedioPuntos()
    {
        List<Cliente> todos = repositorio.ListarTodos();
        if (todos.Count == 0)
        {
            return 0;
        }
        return todos.Average(c => c.PuntosConseguidos);
    }

    public bool PuntosSonValidos(int puntos)
    {
        return puntos >= 0;
    }

    public bool ExisteDni(string dni)
    {
        return repositorio.BuscarPorDni(dni) != null;
    }

    public Cliente Crear(CreateCliente request)
    {
        if (repositorio.BuscarPorDni(request.Dni) != null)
        {
            throw new ConflictoException($"Ya existe un cliente con DNI {request.Dni}");
        }

        Cliente nuevo = new(request.Dni, request.Nombre, request.Apellido, request.Correo, request.Telefono, request.PuntosConseguidos ?? 0);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Cliente Actualizar(string dni, UpdateCliente request)
    {
        Cliente cliente = BuscarPorDni(dni);
        cliente.Nombre = request.Nombre;
        cliente.Apellido = request.Apellido;
        cliente.Correo = request.Correo;
        cliente.Telefono = request.Telefono;
        cliente.SumarPuntos(request.PuntosConseguidos ?? 0);
        return cliente;
    }

    public void Eliminar(string dni)
    {
        bool eliminado = repositorio.EliminarPorDni(dni);
        if (eliminado == false)
        {
            throw new RecursoNoEncontradoException($"No existe un cliente con DNI {dni}");
        }
    }
}
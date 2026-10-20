using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;
using Farmaco.Excepciones;

namespace Farmaco.Servicios;

public class ServicioProveedores(IReProveedor repositorio)
{
    public List<Proovedor> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Proovedor BuscarPorNombre(string nombreProveedor)
    {
        Proovedor? proveedor = repositorio.BuscarPorNombre(nombreProveedor) ?? throw new RecursoNoEncontradoException($"No existe un proveedor con nombre {nombreProveedor}");
        return proveedor;
    }

    public bool TelefonoEsValido(string telefono)
    {
        return telefono.Length == 9;
    }

    public bool ExisteProveedor(string nombreProveedor)
    {
        return repositorio.BuscarPorNombre(nombreProveedor) != null;
    }

    public Proovedor Crear(CreateProveedor request)
    {
        if (repositorio.BuscarPorNombre(request.NombreProveedor) != null)
        {
            throw new ConflictoException($"Ya existe un proveedor con nombre {request.NombreProveedor}");
        }

        Proovedor nuevo = new(request.NombreProveedor, request.TelefonoProveedor, request.DireccionProveedor);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Proovedor Actualizar(string nombreProveedor, UpdateProveedor request)
    {
        Proovedor proveedor = BuscarPorNombre(nombreProveedor);
        proveedor.CambiarNombreProveedor(request.NombreProveedor);
        proveedor.CambiarTelefonoProveedor(request.TelefonoProveedor);
        proveedor.CambiarDireccionProveedor(request.DireccionProveedor);
        return proveedor;
    }

    public void Eliminar(string nombreProveedor)
    {
        bool eliminado = repositorio.EliminarPorNombre(nombreProveedor);
        if (eliminado == false)
        {
            throw new RecursoNoEncontradoException($"No existe un proveedor con nombre {nombreProveedor}");
        }
    }
}
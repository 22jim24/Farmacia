using Farmaco.Dtos;
using Farmaco.Modelos;
using Farmaco.Repositorios;

namespace Farmaco.Servicios;

public class ServicioProveedores(IReProveedor repositorio)
{
    public List<Proovedor> ListarTodos()
    {
        return repositorio.ListarTodos();
    }

    public Proovedor? BuscarPorNombre(string nombreProveedor)
    {
        return repositorio.BuscarPorNombre(nombreProveedor);
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
        Proovedor nuevo = new(request.NombreProveedor, request.TelefonoProveedor, request.DireccionProveedor);
        repositorio.Agregar(nuevo);
        return nuevo;
    }

    public Proovedor? Actualizar(string nombreProveedor, UpdateProveedor request)
    {
        Proovedor? proveedor = repositorio.BuscarPorNombre(nombreProveedor);
        if (proveedor == null)
        {
            return null;
        }

        repositorio.EliminarPorNombre(nombreProveedor);
        Proovedor actualizado = new(nombreProveedor, request.TelefonoProveedor, request.DireccionProveedor);
        repositorio.Agregar(actualizado);
        return actualizado;
    }

    public bool Eliminar(string nombreProveedor)
    {
        return repositorio.EliminarPorNombre(nombreProveedor);
    }
}
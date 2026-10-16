using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public class ReProveedorRam : IReProveedor
{
    private readonly List<Proovedor> proveedores =
    [
        new("Laboratorios Portugal", "987654321", "Av. Industrial 123"),
        new("Química Suiza", "912345678", "Av. República de Panamá 456"),
        new("Farmindustria", "998877665", "Av. Los Frutales 789"),
        new("Medifarma", "955443322", "Jr. Ecuador 321")
    ];

    public void Agregar(Proovedor proveedor)
    {
        proveedores.Add(proveedor);
    }

    public Proovedor? BuscarPorNombre(string nombreProveedor)
    {
        return proveedores.FirstOrDefault(p => p.NombreProveedor == nombreProveedor);
    }

    public List<Proovedor> ListarTodos()
    {
        return proveedores;
    }

    public bool EliminarPorNombre(string nombreProveedor)
    {
        Proovedor? proveedor = BuscarPorNombre(nombreProveedor);
        if (proveedor == null)
        {
            return false;
        }
        proveedores.Remove(proveedor);
        return true;
    }
}
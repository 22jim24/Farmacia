using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public class ReClienteRam : IReCliente
{
    private readonly List<Cliente> clientes =
    [
        new("72451234", "Ana", "Torres", "ana@correo.com", "987654321", 120),
        new("70112233", "Luis", "Ramos", "luis@correo.com", "912345678", 50),
        new("75998877", "Sofía", "Paredes", "sofia@correo.com", "998877665", 200),
        new("71234567", "Marco", "Díaz", "marco@correo.com", "955443322", 10)
    ];

    public void Agregar(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public Cliente? BuscarPorDni(string dni)
    {
        return clientes.FirstOrDefault(c => c.Dni == dni);
    }

    public List<Cliente> ListarTodos()
    {
        return clientes;
    }

    public bool EliminarPorDni(string dni)
    {
        Cliente? cliente = BuscarPorDni(dni);
        if (cliente == null)
        {
            return false;
        }
        clientes.Remove(cliente);
        return true;
    }
}
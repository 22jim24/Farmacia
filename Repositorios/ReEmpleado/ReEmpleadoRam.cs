using Farmaco.Modelos;

namespace Farmaco.Repositorios;

public class ReEmpleadoRam : IReEmpleado
{
    private readonly List<Empleado> empleados =
    [
        new("45123698", "Carlos", "Mendoza", "carlos@farmaco.com", "987111222", "ADMIN"),
        new("48963214", "Elena", "Gómez", "elena@farmaco.com", "987333444", "FARMACEUTICO"),
        new("73216549", "Jorge", "Vargas", "jorge@farmaco.com", "987555666", "CAJERO"),
        new("76549871", "Lucía", "Castro", "lucia@farmaco.com", "987777888", "ALMACENERO")
    ];

    public void Agregar(Empleado empleado)
    {
        empleados.Add(empleado);
    }

    public Empleado? BuscarPorDni(string dni)
    {
        return empleados.FirstOrDefault(e => e.Dni == dni);
    }

    public List<Empleado> ListarTodos()
    {
        return empleados;
    }

    public bool EliminarPorDni(string dni)
    {
        Empleado? empleado = BuscarPorDni(dni);
        if (empleado == null)
        {
            return false;
        }
        empleados.Remove(empleado);
        return true;
    }
}

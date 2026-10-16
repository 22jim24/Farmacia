namespace Farmaco.Modelos;

public class Empleado : Persona
{
    public string Cargo { get; private set; } = string.Empty;   
    public Empleado(string dni, string nombre, string apellido, string correo, string telefono, string cargo) : base(dni, nombre, apellido, correo, telefono)
    {
        CambiarCargo(cargo);
    }

    public void CambiarCargo(string nuevoCargo)
    {
        if (nuevoCargo != "ADMIN" && nuevoCargo != "FARMACEUTICO" && nuevoCargo != "CAJERO" && nuevoCargo != "ALMACENERO")
        {
            throw new ArgumentException("El cargo debe ser ADMIN, FARMACEUTICO, CAJERO o ALMACENERO");
        }
        Cargo = nuevoCargo;
    }

    public override string ObtenerRol() => "empleado";
}
namespace Farmaco.Modelos;

public abstract class Persona(string dni, string nombre , string apellido, 
string correo, string telefono)
{
    public string Dni { get; } = dni;
    public string Nombre { get; set; } = nombre;
    public string Apellido { get; set; } = apellido;
    public string Correo { get; set; } = correo;
    public string Telefono { get; set; } = telefono;


    public abstract string ObtenerRol();
}

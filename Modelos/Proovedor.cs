namespace Farmaco.Modelos;

public class Proovedor
{
    public string NombreProveedor { get; private set; }= string.Empty; 
    public string TelefonoProveedor { get; private set; } = string.Empty;
    public string DireccionProveedor { get; private set; } = string.Empty;

    public Proovedor(string nombreProveedor, string telefonoProveedor, string direccionProveedor)
    {
        if (telefonoProveedor.Length != 9)
        {
            throw new ArgumentException("El teléfono del proveedor debe tener 9 dígitos.");
        }

        NombreProveedor = nombreProveedor;
        TelefonoProveedor = telefonoProveedor;
        DireccionProveedor = direccionProveedor;
    }

    public void CambiarNombreProveedor(string nuevoNombre)
    {
        NombreProveedor = nuevoNombre;
    }

    public void CambiarTelefonoProveedor(string nuevoTelefono)
    {
        if (nuevoTelefono.Length != 9)
        {
            throw new ArgumentException("El teléfono del proveedor debe tener 9 dígitos.");
        }
        TelefonoProveedor = nuevoTelefono;
    }

    public void CambiarDireccionProveedor(string nuevaDireccion)
    {
        DireccionProveedor = nuevaDireccion;
    }
}
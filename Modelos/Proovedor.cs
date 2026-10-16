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

        TelefonoProveedor = telefonoProveedor;
        DireccionProveedor = direccionProveedor;
        NombreProveedor = nombreProveedor;


    }
}
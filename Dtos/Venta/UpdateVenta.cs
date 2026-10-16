namespace Farmaco.Dtos;

public class UpdateVenta
{
    public string NombreCliente { get; set; } = "";
    public string NombreProducto { get; private set; } = "";
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public string MetodoPago { get; set; } = "";
    
}
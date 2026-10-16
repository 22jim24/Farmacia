namespace Farmaco.Dtos;

public class CreateVenta
{
    public string NombreCliente { get; set; } = "";
    public string NombreProducto { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public string MetodoPago { get; set; } = "";
}
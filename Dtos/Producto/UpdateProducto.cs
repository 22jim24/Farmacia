namespace Farmaco.Dtos;
public class UpdateProducto
{
    public string Nombre { get; set; } = "";
    public decimal? Precio { get; set; }
    public int? Stock { get; set; }
}
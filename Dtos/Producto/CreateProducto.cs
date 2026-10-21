using System.ComponentModel.DataAnnotations;

namespace Farmaco.Dtos;
public class CreateProducto
{
    [Required (ErrorMessage = "El nombre es obligatorio")]
    [StringLength(59, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 59 caracteres")]
    public string Nombre { get; set; } = "";

    [Required (ErrorMessage = "El precio es obligatorio")]
    [Range(0.1, 1000, ErrorMessage = "El precio debe ser un valor positivo")]
    public decimal? Precio { get; set; }

    [Required (ErrorMessage = "El stock es obligatorio")]
    [Range(0, 100, ErrorMessage = "El stock debe ser un valor positivo")]
    public int? Stock { get; set; }
}
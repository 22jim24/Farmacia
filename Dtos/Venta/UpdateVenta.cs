using System.ComponentModel.DataAnnotations;

namespace Farmaco.Dtos;

public class UpdateVenta
{
    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del cliente debe tener entre 3 y 100 caracteres")]
    public string NombreCliente { get; set; } = "";

    [Required(ErrorMessage = "El nombre del producto es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del producto debe tener entre 3 y 100 caracteres")]
    public string NombreProducto { get; private set; } = "";

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, 1000, ErrorMessage = "La cantidad debe ser al menos 1")]
    public int? Cantidad { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.1, 100, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal? Precio { get; set; }
    
    [Required(ErrorMessage = "El método de pago es obligatorio")]   
    
    public string MetodoPago { get; set; } = "";
    
}
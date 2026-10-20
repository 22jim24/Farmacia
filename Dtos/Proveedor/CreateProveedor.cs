using System.ComponentModel.DataAnnotations;

namespace Farmaco.Dtos;

public class CreateProveedor
{
    [Required(ErrorMessage = "El nombre del proveedor es obligatorio")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 60 caracteres")]
    public string NombreProveedor { get; set; } = "";

    [Required(ErrorMessage = "El teléfono del proveedor es obligatorio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "El teléfono del proveedor debe tener 9 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo debe contener números")]
    public string TelefonoProveedor { get; set; } = "";


    [Required(ErrorMessage = "La dirección del proveedor es obligatoria")]
    [StringLength(200, MinimumLength = 10, ErrorMessage = "La dirección debe tener entre 10 y 200 caracteres")]
    public string DireccionProveedor { get; set; } = "";
}
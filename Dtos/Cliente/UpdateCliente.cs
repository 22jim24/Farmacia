using System.ComponentModel.DataAnnotations;

namespace Farmaco.Dtos;
public class UpdateCliente
{
    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "debe tener entre 3 y 50 caracteres")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "debe tener entre 3 y 50 caracteres")]
    public string Apellido { get; set; } = "";

    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "debe tener entre 3 y 50 caracteres")]
    public string Correo { get; set; } = "";

    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "debe tener 9 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "solo debe contener números")]
    public string Telefono { get; set; } = "";


    [Required(ErrorMessage = "Los puntos son obligatorios")]
    [Range(0, 100, ErrorMessage = "Los puntos no pueden ser negativos")]
    public int? PuntosConseguidos { get; set; }
}

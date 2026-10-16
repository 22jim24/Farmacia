using System.ComponentModel.DataAnnotations;
namespace Farmaco.Dtos;

public class CreateEmpleado
{
    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El DNI solo debe contener números")]
    public string Dni { get; set; } = "";

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 100 caracteres")]
    public string Apellido { get; set; } = "";

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Correo { get; set; } = "";

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "El teléfono debe tener 9 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo debe contener números")]
    public string Telefono { get; set; } = "";

    [Required(ErrorMessage = "El cargo es obligatorio")]
    [RegularExpression("^(ADMIN|FARMACEUTICO|CAJERO|ALMACENERO)$", ErrorMessage = "El cargo debe ser ADMIN, FARMACEUTICO, CAJERO o ALMACENERO")]
    public string Cargo { get; set; } = "";
}

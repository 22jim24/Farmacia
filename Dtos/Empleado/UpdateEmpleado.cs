using System.ComponentModel.DataAnnotations;
namespace Farmaco.Dtos;

public class UpdateEmpleado
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = "";
    
    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Apellido { get; set; } = "";

    [Required(ErrorMessage = "es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Correo { get; set; } = "";

    [Required(ErrorMessage = "es obligatorio")]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "El teléfono debe tener entre 7 y 15 dígitos")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El teléfono solo debe contener números")]
    public string Telefono { get; set; } = "";

    [Required(ErrorMessage = "El cargo es obligatorio")]
    [RegularExpression("^(ADMIN|FARMACEUTICO|CAJERO|ALMACENERO)$", ErrorMessage = "El cargo debe ser ADMIN, FARMACEUTICO, CAJERO o ALMACENERO")]
    public string Cargo { get; set; } = "";
}

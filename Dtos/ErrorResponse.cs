namespace Farmaco.Dtos;

public class ErrorResponse(int status, string mensaje)
{
    public int Status { get; } = status;
    public string Mensaje { get; } = mensaje;
    public DateTime Fecha { get; } = DateTime.Now;
}
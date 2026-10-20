using Farmaco.Dtos;
using Farmaco.Excepciones;

namespace Farmaco.Middlewares;

public class ManejoErroresMiddleware(RequestDelegate siguiente, ILogger<ManejoErroresMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext contexto)
    {
        try
        {
            await siguiente(contexto);
        }
        catch (Exception ex)
        {
            await ResponderErrorAsync(contexto, ex);
        }
    }

    private async Task ResponderErrorAsync(HttpContext contexto, Exception ex)
    {
        int status;
        string mensaje;

        if (ex is RecursoNoEncontradoException)
        {
            status = 404;
            mensaje = ex.Message;
        }
        else if (ex is ConflictoException)
        {
            status = 409;
            mensaje = ex.Message;
        }
        else if (ex is ArgumentException)
        {
            status = 400;
            mensaje = ex.Message;
        }
        else
        {
            status = 500;
            mensaje = "oclcurio un error inesperado. Intente nuevamente.";
            logger.LogError(ex, "Error no controlado");
        }

        ErrorResponse respuesta = new(status, mensaje);
        contexto.Response.StatusCode = status;
        await contexto.Response.WriteAsJsonAsync(respuesta);
    }
}
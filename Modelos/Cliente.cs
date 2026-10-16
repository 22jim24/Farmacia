namespace Farmaco.Modelos;

public class Cliente : Persona
{
    public int PuntosConseguidos { get; private set; }
    public Cliente(string dni, string nombre, string apellido, string correo,
    string telefono,int puntosConseguidos) : base(dni, nombre, apellido, correo, telefono)
    {
        SumarPuntos(puntosConseguidos);
    }

    public void SumarPuntos(int puntosAdicionales)
        {
            if (puntosAdicionales < 0)
            {
                throw new ArgumentException("Los puntos a sumar no pueden ser negativos.");
            }
            PuntosConseguidos += puntosAdicionales;
        }

 
    public override string ObtenerRol() => "cliente";
}
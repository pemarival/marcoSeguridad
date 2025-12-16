using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class SesionUsuarioService
{
    static List<SesionUsuario> Sesiones { get; }
    static int nextId = 2;

    static SesionUsuarioService()
    {
        Sesiones = new List<SesionUsuario>
        {
            new SesionUsuario
            {
                SesionID = 1,
                UsuarioID = 1,
                FechaInicio = DateTime.Now,
                IP_Origen = "127.0.0.1",
                EstadoSesion = "ACTIVA"
            }
        };
    }

    // GET ALL
    public static List<SesionUsuario> GetAll() => Sesiones;

    // GET BY ID
    public static SesionUsuario? Get(int id) =>
        Sesiones.FirstOrDefault(s => s.SesionID == id);

    // ADD
    public static void Add(SesionUsuario sesion)
    {
        sesion.SesionID = nextId++;
        sesion.FechaInicio = DateTime.Now;
        sesion.EstadoSesion = "ACTIVA";
        Sesiones.Add(sesion);
    }

    // DELETE
    public static void Delete(int id)
    {
        var sesion = Get(id);
        if (sesion is null)
            return;

        Sesiones.Remove(sesion);
    }

    // UPDATE
    public static void Update(SesionUsuario sesion)
    {
        var index = Sesiones.FindIndex(
            s => s.SesionID == sesion.SesionID
        );

        if (index == -1)
            return;

        Sesiones[index] = sesion;
    }
}

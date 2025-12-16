using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class ConfiguracionService
{
    static List<Configuracion> Configuraciones { get; }
    static int nextId = 3;

    static ConfiguracionService()
    {
        Configuraciones = new List<Configuracion>
        {
            new Configuracion
            {
                ConfiguracionID = 1,
                NombreConfiguracion = "TiempoSesion",
                ValorConfiguracion = "30",
                Descripcion = "Tiempo de sesión en minutos"
            },
            new Configuracion
            {
                ConfiguracionID = 2,
                NombreConfiguracion = "IntentosMaximos",
                ValorConfiguracion = "5",
                Descripcion = "Cantidad máxima de intentos fallidos"
            }
        };
    }

    // GET ALL
    public static List<Configuracion> GetAll() => Configuraciones;

    // GET BY ID
    public static Configuracion? Get(int id) =>
        Configuraciones.FirstOrDefault(c => c.ConfiguracionID == id);

    // ADD
    public static void Add(Configuracion configuracion)
    {
        configuracion.ConfiguracionID = nextId++;
        Configuraciones.Add(configuracion);
    }

    // DELETE
    public static void Delete(int id)
    {
        var configuracion = Get(id);
        if (configuracion is null)
            return;

        Configuraciones.Remove(configuracion);
    }

    // UPDATE
    public static void Update(Configuracion configuracion)
    {
        var index = Configuraciones.FindIndex(
            c => c.ConfiguracionID == configuracion.ConfiguracionID
        );

        if (index == -1)
            return;

        Configuraciones[index] = configuracion;
    }
}

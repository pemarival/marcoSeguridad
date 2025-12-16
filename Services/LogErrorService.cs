using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class LogErrorService
{
    static List<LogError> LogErrores { get; }
    static int nextId = 2;

    static LogErrorService()
    {
        LogErrores = new List<LogError>
        {
            new LogError
            {
                ErrorID = 1,
                Fecha = DateTime.Now,
                UsuarioID = null,
                TipoError = "EXCEPTION",
                Descripcion = "NullReferenceException",
                IP_Origen = "127.0.0.1"
            }
        };
    }

    // GET ALL
    public static List<LogError> GetAll() => LogErrores;

    // GET BY ID
    public static LogError? Get(int id) =>
        LogErrores.FirstOrDefault(e => e.ErrorID == id);

    // ADD
    public static void Add(LogError logError)
    {
        logError.ErrorID = nextId++;
        logError.Fecha = DateTime.Now;
        LogErrores.Add(logError);
    }

    // DELETE
    public static void Delete(int id)
    {
        var logError = Get(id);
        if (logError is null)
            return;

        LogErrores.Remove(logError);
    }

    // UPDATE
    public static void Update(LogError logError)
    {
        var index = LogErrores.FindIndex(
            e => e.ErrorID == logError.ErrorID
        );

        if (index == -1)
            return;

        LogErrores[index] = logError;
    }
}

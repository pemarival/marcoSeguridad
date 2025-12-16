using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class AuditoriaService
{
    static List<Auditoria> Auditorias { get; }
    static int nextId = 2;

    static AuditoriaService()
    {
        Auditorias = new List<Auditoria>
        {
            new Auditoria
            {
                AuditoriaID = 1,
                UsuarioID = 1,
                Accion = "LOGIN",
                Fecha = DateTime.Now,
                Descripcion = "Inicio de sesión exitoso",
                IP_Origen = "127.0.0.1",
                Aplicacion = "MarcoSeguridad"
            }
        };
    }

    // GET ALL
    public static List<Auditoria> GetAll() => Auditorias;

    // GET BY ID
    public static Auditoria? Get(int id) =>
        Auditorias.FirstOrDefault(a => a.AuditoriaID == id);

    // ADD
    public static void Add(Auditoria auditoria)
    {
        auditoria.AuditoriaID = nextId++;
        auditoria.Fecha = DateTime.Now;
        Auditorias.Add(auditoria);
    }

    // DELETE
    public static void Delete(int id)
    {
        var auditoria = Get(id);
        if (auditoria is null)
            return;

        Auditorias.Remove(auditoria);
    }

    // UPDATE
    public static void Update(Auditoria auditoria)
    {
        var index = Auditorias.FindIndex(
            a => a.AuditoriaID == auditoria.AuditoriaID
        );

        if (index == -1)
            return;

        Auditorias[index] = auditoria;
    }
}

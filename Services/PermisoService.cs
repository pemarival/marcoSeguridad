using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class PermisoService
{
    static List<Permiso> Permisos { get; }
    static int nextId = 2;

    static PermisoService()
    {
        Permisos = new List<Permiso>
        {
            new Permiso
            {
                PermisoID = 1,
                NombrePermiso = "VER_USUARIOS",
                Descripcion = "Permite consultar usuarios"
            }
        };
    }

    // GET ALL
    public static List<Permiso> GetAll() => Permisos;

    // GET BY ID
    public static Permiso? Get(int id) =>
        Permisos.FirstOrDefault(p => p.PermisoID == id);

    // ADD
    public static void Add(Permiso permiso)
    {
        permiso.PermisoID = nextId++;
        Permisos.Add(permiso);
    }

    // DELETE
    public static void Delete(int id)
    {
        var permiso = Get(id);
        if (permiso is null)
            return;

        Permisos.Remove(permiso);
    }

    // UPDATE
    public static void Update(Permiso permiso)
    {
        var index = Permisos.FindIndex(
            p => p.PermisoID == permiso.PermisoID
        );

        if (index == -1)
            return;

        Permisos[index] = permiso;
    }
}

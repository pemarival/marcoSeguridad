using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class RolPermisoService
{
    static List<RolPermiso> RolPermisos { get; }

    static RolPermisoService()
    {
        RolPermisos = new List<RolPermiso>
        {
            new RolPermiso
            {
                RolID = 1,
                PermisoID = 1,
                FechaAsignacion = DateTime.Now
            }
        };
    }

    // GET ALL
    public static List<RolPermiso> GetAll() => RolPermisos;

    // GET BY KEY (RolID + PermisoID)
    public static RolPermiso? Get(int rolId, int permisoId) =>
        RolPermisos.FirstOrDefault(
            rp => rp.RolID == rolId && rp.PermisoID == permisoId
        );

    // ADD
    public static void Add(RolPermiso rolPermiso)
    {
        rolPermiso.FechaAsignacion = DateTime.Now;
        RolPermisos.Add(rolPermiso);
    }

    // DELETE
    public static void Delete(int rolId, int permisoId)
    {
        var rolPermiso = Get(rolId, permisoId);
        if (rolPermiso is null)
            return;

        RolPermisos.Remove(rolPermiso);
    }

    // UPDATE
    public static void Update(RolPermiso rolPermiso)
    {
        var index = RolPermisos.FindIndex(
            rp => rp.RolID == rolPermiso.RolID &&
                  rp.PermisoID == rolPermiso.PermisoID
        );

        if (index == -1)
            return;

        RolPermisos[index] = rolPermiso;
    }
}

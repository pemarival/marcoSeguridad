using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class UsuarioRolService
{
    static List<UsuarioRol> UsuarioRoles { get; }

    static UsuarioRolService()
    {
        UsuarioRoles = new List<UsuarioRol>
        {
            new UsuarioRol
            {
                UsuarioID = 1,
                RolID = 1,
                FechaAsignacion = DateTime.Now.AddDays(-10)
            },
            new UsuarioRol
            {
                UsuarioID = 1,
                RolID = 2,
                FechaAsignacion = DateTime.Now.AddDays(-5)
            },
            new UsuarioRol
            {
                UsuarioID = 2,
                RolID = 1,
                FechaAsignacion = DateTime.Now.AddDays(-3)
            }
        };
    }

    // GET ALL
    public static List<UsuarioRol> GetAll() => UsuarioRoles;

    // GET BY COMPOSITE KEY
    public static UsuarioRol? Get(int usuarioId, int rolId) =>
        UsuarioRoles.FirstOrDefault(ur =>
            ur.UsuarioID == usuarioId && ur.RolID == rolId);

    // ADD
    public static void Add(UsuarioRol usuarioRol)
    {
        UsuarioRoles.Add(usuarioRol);
    }

    // DELETE
    public static void Delete(int usuarioId, int rolId)
    {
        var usuarioRol = Get(usuarioId, rolId);
        if (usuarioRol is null)
            return;

        UsuarioRoles.Remove(usuarioRol);
    }

    // UPDATE
    public static void Update(UsuarioRol usuarioRol)
    {
        var index = UsuarioRoles.FindIndex(ur =>
            ur.UsuarioID == usuarioRol.UsuarioID &&
            ur.RolID == usuarioRol.RolID);

        if (index == -1)
            return;

        UsuarioRoles[index] = usuarioRol;
    }
}


using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class RolService
{
    static List<Rol> Roles { get; }
    static int nextId = 2;

    static RolService()
    {
        Roles = new List<Rol>
        {
            new Rol
            {
                RolID = 1,
                NombreRol = "ADMIN",
                Descripcion = "Administrador del sistema"
            }
        };
    }

    // GET ALL
    public static List<Rol> GetAll() => Roles;

    // GET BY ID
    public static Rol? Get(int id) =>
        Roles.FirstOrDefault(r => r.RolID == id);

    // ADD
    public static void Add(Rol rol)
    {
        rol.RolID = nextId++;
        Roles.Add(rol);
    }

    // DELETE
    public static void Delete(int id)
    {
        var rol = Get(id);
        if (rol is null)
            return;

        Roles.Remove(rol);
    }

    // UPDATE
    public static void Update(Rol rol)
    {
        var index = Roles.FindIndex(
            r => r.RolID == rol.RolID
        );

        if (index == -1)
            return;

        Roles[index] = rol;
    }
}

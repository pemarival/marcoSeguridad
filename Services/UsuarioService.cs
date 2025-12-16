using marcoSeguridad.Models;

namespace marcoSeguridad.Services;

public static class UsuarioService
{
    static List<Usuario> Usuarios { get; }
    static int nextId = 2;

    static UsuarioService()
    {
        Usuarios = new List<Usuario>
        {
            new Usuario
            {
                UsuarioID = 1,
                NombreUsuario = "admin",
                Contraseña = "Admin123",
                EstadoUsuario = true,
                TipoAutenticacion = "SQL",
                FechaCreacion = DateTime.Now,
                UltimoAcceso = null
            }
        };
    }

    // GET ALL
    public static List<Usuario> GetAll() => Usuarios;

    // GET BY ID
    public static Usuario? Get(int id) =>
        Usuarios.FirstOrDefault(u => u.UsuarioID == id);

    // ADD
    public static void Add(Usuario usuario)
    {
        usuario.UsuarioID = nextId++;
        usuario.FechaCreacion = DateTime.Now;
        Usuarios.Add(usuario);
    }

    // DELETE
    public static void Delete(int id)
    {
        var usuario = Get(id);
        if (usuario is null)
            return;

        Usuarios.Remove(usuario);
    }

    // UPDATE
    public static void Update(Usuario usuario)
    {
        var index = Usuarios.FindIndex(
            u => u.UsuarioID == usuario.UsuarioID
        );

        if (index == -1)
            return;

        Usuarios[index] = usuario;
    }
}

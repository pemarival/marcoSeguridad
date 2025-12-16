namespace marcoSeguridad.Models;

public class Rol
{
    public int RolID { get; set; }
    public string NombreRol { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public List<UsuarioRol> UsuarioRoles { get; set; } = new();
    public List<RolPermiso> RolPermisos { get; set; } = new();
}

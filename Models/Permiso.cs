namespace marcoSeguridad.Models;

public class Permiso
{
    public int PermisoID { get; set; }
    public string NombrePermiso { get; set; } = string.Empty;
    public string? Descripcion { get; set; }

    public List<RolPermiso> RolPermisos { get; set; } = new();
}

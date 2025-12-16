namespace marcoSeguridad.Models;

public class RolPermiso
{
    public int RolID { get; set; }
    public Rol Rol { get; set; } = null!;

    public int PermisoID { get; set; }
    public Permiso Permiso { get; set; } = null!;

    public DateTime FechaAsignacion { get; set; }
}

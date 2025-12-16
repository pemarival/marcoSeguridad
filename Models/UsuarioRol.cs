namespace marcoSeguridad.Models;

public class UsuarioRol
{
    public int UsuarioID { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public int RolID { get; set; }
    public Rol Rol { get; set; } = null!;

    public DateTime FechaAsignacion { get; set; }
}

namespace marcoSeguridad.Models;

public class Usuario
{
    public int UsuarioID { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
    public bool EstadoUsuario { get; set; }
    public string TipoAutenticacion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
    public DateTime? UltimoAcceso { get; set; }

    // Relaciones
    public List<UsuarioRol> UsuarioRoles { get; set; } = new();
    public List<SesionUsuario> Sesiones { get; set; } = new();
    public List<Auditoria> Auditorias { get; set; } = new();
    public List<LogError> LogErrores { get; set; } = new();
}

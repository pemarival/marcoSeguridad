namespace marcoSeguridad.Models;

public class Auditoria
{
    public int AuditoriaID { get; set; }
    public int UsuarioID { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public string Accion { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string? Descripcion { get; set; }
    public string IP_Origen { get; set; } = string.Empty;
    public string Aplicacion { get; set; } = string.Empty;
}

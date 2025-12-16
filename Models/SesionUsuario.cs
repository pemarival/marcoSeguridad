namespace marcoSeguridad.Models;

public class SesionUsuario
{
    public int SesionID { get; set; }
    public int UsuarioID { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string IP_Origen { get; set; } = string.Empty;
    public string EstadoSesion { get; set; } = string.Empty;
}

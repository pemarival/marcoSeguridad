namespace marcoSeguridad.Models;

public class LogError
{
    public int ErrorID { get; set; }
    public DateTime Fecha { get; set; }

    public int? UsuarioID { get; set; }
    public Usuario? Usuario { get; set; }

    public string TipoError { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string IP_Origen { get; set; } = string.Empty;
}

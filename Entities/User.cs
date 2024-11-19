namespace Entities;

public class Usuario
{
    public string? UsuarioId { get; set; }
    public string? TipoDocumento { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Password { get; set; }
    public TipoUsuario TipoUsuario { get; set; } // Mirar
    public DateTime FechaRegistro { get; set; }
    public bool Estado { get; set; }
}
public enum TipoUsuario
{
    Admin,
    Beneficiario,
    Afiliado,
    Normal
}
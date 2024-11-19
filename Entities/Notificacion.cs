namespace Entities
{
    public class Notificacion
    {
        public int NotificacionId { get; set; }
        public string UsuarioId { get; set; }
        public TiposNot Tipo { get; set; } 
        public string? Titulo { get; set; }
        public bool Leido { get; set; }
        public DateTime FechaEnvio { get; set; }
    }

    public enum TiposNot
    {
        sms, email, llamada
    }
}
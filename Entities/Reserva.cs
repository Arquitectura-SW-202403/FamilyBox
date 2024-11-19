namespace Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public string UsuarioId { get; set; }
        public int InstalacionId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public decimal Tarifa { get; set; }
        public Estadopago Estado { get; set; } 
        public DateTime Creacion { get; set; }
    }
}
namespace Entities
{
    public class Evento
    {
        public int EventoId { get; set; }
        public int SedeId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int capcidad { get; set; }
        public decimal TarifaAfiliado { get; set; }
        public decimal TarifaNoAfiliado { get; set; }
        public bool Estado { get; set; }

    }
}
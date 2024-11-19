namespace Entities
{
   public class Pago
   {
      public int PagoId { get; set; }
      public string UsuarioId { get; set; }
      public int TransaccionId { get; set; }
      public string? Tipo { get; set; }
      public decimal Monto { get; set; }
      public Metodopago MetodoPago { get; set; }
      public Estadopago EstadoPago { get; set; }
      public DateTime FechaPago { get; set; }
   }

   public enum Metodopago
   {
      Efecty, PayPal, Tarjeta, Banco
   }
   public enum Estadopago
   {
      Completado, Tramitando, Rechazado
   }

}


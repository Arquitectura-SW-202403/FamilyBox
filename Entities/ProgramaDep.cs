namespace Entities
{
    public class ProgramaDep
    {
        public int ProgramaId {get;set;}
        public int SedeId {get;set;}
        public string ? Nombre {get;set;}
        public string ? Descripcion {get;set;}
        public string ? TipoActividad {get;set;} 
        public int Cupo {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFin {get;set;}
        public decimal TarifaAfiliado {get;set;}
        public decimal TarifaNoAfiliado {get;set;}
        public bool Estado {get;set;}
    }
}
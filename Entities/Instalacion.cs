namespace Entities
{
    public class Instalacion
    {
        public int InstalacionId {get;set;}
        public int SedeId {get;set;}
        public string ? Nombre {get;set;}
        public String ? Tipo {get;set;}
        public int Capacidad {get;set;}
        public string ? Descripcion {get;set;}
        public bool Estado {get;set;}
        public Disponibilidadenum Disponibilidad {get;set;} 

    }
    public enum Disponibilidadenum{
        Gimnasio,Cancha,Piscina,Salon,Juegos,etc
    }
}
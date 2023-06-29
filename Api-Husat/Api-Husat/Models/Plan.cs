namespace Api_Husat.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string tipoContrato { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } = string.Empty;
        public TipoTarifa tipoTarifa { get; set; }
        public TipoPlan tipoPlan { get; set; }
        public Ciclo ciclo { get; set; }    
        public Plataforma plataforma { get; set; }
    }
    public class TipoTarifa
    {
        public int Id { get; set; }= 0;
        public string Nombre { get; set; } = string.Empty;

    }
    public class TipoPlan
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
    public class Ciclo
    {
        public int Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
    public class Plataforma
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}

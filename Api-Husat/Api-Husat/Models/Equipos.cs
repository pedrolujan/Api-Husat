namespace Api_Husat.Models
{
    public class Equipos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Imei { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string codDocCompra { get; set; } = string.Empty;
        public MarcaEquipo marcaEquipo { get; set; } 
        public ModeloEquipo modeloEquipo { get; set; }

    }
    public class MarcaEquipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class ModeloEquipo
    {
        public int Id { get; set; }
        public string Nombre { get; set;}

    }
}

namespace Api_Husat.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public ClaseVehiculo claseVehiculo { get; set; } 
        public MarcaVehiculo marcaVehiculo { get; set; }
        public ModeloVehiculo modeloVehiculo { get; set;}

        public ModoUso modoUso { get; set; } 


        
    }

    public class ClaseVehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    public class MarcaVehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class ModeloVehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
    public class ModoUso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

}

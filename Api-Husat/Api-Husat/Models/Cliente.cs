namespace Api_Husat.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nombres { get; set; }
        public int Edad { get; set; }
        public string ApellidosPaterno { get; set; }
        public string ApellidosMaterno { get; set; } = string.Empty;
        public string documentoIdentidad { get; set; } = string.Empty;
        public string Celular { get; set;} = string.Empty;
        public string Contacto1 { get; set; } = string.Empty;
        public string Contacto2 { get; set; } = string.Empty;   
        public string CelularContacto1 { get; set; } = string.Empty; 
        public string CelularContacto2 { get; set; } = string.Empty; 

    }
}

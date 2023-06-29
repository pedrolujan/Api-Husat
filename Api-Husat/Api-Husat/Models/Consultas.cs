namespace Api_Husat.Models
{
    public class Consultas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Equipos equipo { get; set; }
        public Cliente cliente { get; set; }
        public Vehiculo vehiculo { get; set; }
        public SimCard simCard { get; set; }
        public Plan plan { get; set; }

    }
}

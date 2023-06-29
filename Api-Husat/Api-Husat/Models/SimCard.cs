namespace Api_Husat.Models
{
    public class SimCard
    {
        public int Id { get; set; }
        public string cSimCard { get; set; }
        public string Description { get; set; }
        public string NumRecibo { get; set; }
        public Operador operador { get; set; }
    }
    public class Operador
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}

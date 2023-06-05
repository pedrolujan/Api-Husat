namespace Api_Husat.Models
{
    public class Personal
    {
        public int IdAcceso { get; set; }
        public int idUsuario { get; set; }
        public int idPersonal { get; set; }
        public string cUsuario { get; set; }
        public string cPrimerNom { get; set; }
        public string cApePat { get; set; }
        public string cApeMat { get; set; }
        public string cDireccion { get; set; }
        public string cDocumento { get; set; }
        public string codTema { get; set; }
        public byte[] btImgPerfil { get; set; }
    }
}

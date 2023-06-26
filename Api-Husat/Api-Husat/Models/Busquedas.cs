namespace Api_Husat.Models
{
    public class Busquedas
    {
        public Busquedas() { }

        public Boolean _chkActivarFechas { get; set; }
        public Boolean _chkActivarDia { get; set; }
        public String _dtFechaIni { get; set; }
        public String _dtFechaFin { get; set; }
        public String _cod1 { get; set; }
        public String _cod2 { get; set; }
        public String _cod3 { get; set; }
        public String _cod4 { get; set; }
        public String _cod5 { get; set; }
        public String _cod6 { get; set; }
        public String _cod7 { get; set; }
        public String _cBuscar { get; set; }
        public Int32 _numPagina { get; set; }
        public Int32 _tipoCon { get; set; }
        public Int32 _idUsuario { get; set; }
    }
}

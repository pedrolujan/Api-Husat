namespace Api_Husat.Models
{
    public class Dashboard
    {
        public Dashboard() { }

        public Int32 numero { get; set; }
        public String Codigoreporte { get; set; }
        public String cUsuario { get; set; }
        public String Detallereporte { get; set; }
        public String MasDetallereporte { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 idOperacion { get; set; }
        public Decimal ImporteRow { get; set; }
        public Decimal ImporteTipoCambio { get; set; }

        public Double ImporteSumado { get; set; }
        public String MonImporteSumado { get; set; }
        public Double ImporteTotal { get; set; }
        public Int32 idMoneda { get; set; }
        public Int32 idAuxiliar { get; set; }
        public String codAuxiliar { get; set; }
        public String codAuxiliar1 { get; set; }
        public String SimboloMoneda { get; set; }
        public String MonImporteRow { get; set; }
        public Boolean estado { get; set; }
        public DateTime dFecha { get; set; }
    }
}

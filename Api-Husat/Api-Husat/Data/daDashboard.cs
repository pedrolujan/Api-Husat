using System.Data.SqlClient;
using System.Data;
using Api_Husat.Models;

namespace Api_Husat.Data
{
    public class daDashboard
    {
        public List<Dashboard> daBuscarCajasDashboard(int tipoCon)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVenta = new DataTable();
            Connection objCnx = null;
            List<Dashboard> lst = new List<Dashboard>();

            try
            {

                pa[0] = new SqlParameter("@tipoCon", SqlDbType.Int);
                pa[0].Value = tipoCon;

                objCnx = new Connection("");
                dtVenta = objCnx.EjecutarProcedimientoDT("upsBuscarCajasDashboard", pa);

                lst = new List<Dashboard>();
                foreach (DataRow dr in dtVenta.Rows)
                {
                    lst.Add(new Dashboard
                    {
                        Codigoreporte = Convert.ToString(dr["id"]),
                        MasDetallereporte = ConvertirPrimeraLetraMayuscula(Convert.ToString(dr["masdetalle"])),
                        Detallereporte = ConvertirPrimeraLetraMayuscula(dr["detalle"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(1),
                        SimboloMoneda = Convert.ToString("S/."),
                        ImporteTipoCambio = Convert.ToDecimal(0),
                        ImporteRow = Convert.ToDecimal(0),

                    });
                }

                return lst;

            }
            catch (Exception ex)
            {
                return lst;
                //throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lst = null;
            }



        }

        public Tuple<List<Dashboard>, List<Dashboard>> daBuscarDashBoardIngresos(Busquedas clsBusq)
        {
            SqlParameter[] pa = new SqlParameter[12];
            DataSet dtMenu = new DataSet();
            List<Dashboard> lsRepBloque = new List<Dashboard>();
            List<Dashboard> lstCajaChica = new List<Dashboard>();
            DataView dvCajaChica = new DataView();
            Connection objCnx = null;
            try
            {
                pa[0] = new SqlParameter("@dtFechaIni", SqlDbType.Date) { Value = clsBusq._dtFechaIni };
                pa[1] = new SqlParameter("@dtFechaFin", SqlDbType.Date) { Value = clsBusq._dtFechaFin };
                pa[2] = new SqlParameter("@codTipoReporte", SqlDbType.VarChar) { Value = clsBusq._cod1 };
                pa[3] = new SqlParameter("@codTipoOperacion", SqlDbType.VarChar) { Value = clsBusq._cod2 };
                pa[4] = new SqlParameter("@idUsuario", SqlDbType.Int) { Value = clsBusq._cod3 };
                pa[5] = new SqlParameter("@codSubConsulta", SqlDbType.VarChar) { Value = clsBusq._cod4 };
                pa[6] = new SqlParameter("@idTipoTarifa", SqlDbType.Int) { Value = 0 };
                pa[7] = new SqlParameter("@cBuscar", SqlDbType.VarChar) { Value = clsBusq._cBuscar };
                pa[8] = new SqlParameter("@numPagina", SqlDbType.VarChar) { Value = clsBusq._numPagina };
                pa[9] = new SqlParameter("@tipoCon", SqlDbType.VarChar) { Value = clsBusq._tipoCon };
                pa[10] = new SqlParameter("@chkHabilitarFecha", SqlDbType.TinyInt) { Value = clsBusq._chkActivarFechas };
                pa[11] = new SqlParameter("@chkDiaEspecifico", SqlDbType.TinyInt) { Value = clsBusq._chkActivarDia };

                objCnx = new Connection("");

                dtMenu = objCnx.EjecutarProcedimientoDS("uspBuscarDashBoard", pa);
                dvCajaChica = new DataView(dtMenu.Tables[0]);
                

                foreach (DataRowView dr in dvCajaChica)
                {
                    lstCajaChica.Add(new Dashboard
                    {
                        Codigoreporte = Convert.ToString(dr["id"]),
                        codAuxiliar = Convert.ToString(dr["codigoValida"]),
                        Detallereporte = ConvertirPrimeraLetraMayuscula(dr["nomCajaChica"].ToString()),
                        Cantidad = Convert.ToInt32(dr["cantidad"]),
                        idMoneda = Convert.ToInt32(dr["idMoneda"]),
                        SimboloMoneda = Convert.ToInt32(dr["idMoneda"]) == 1 ? "S/." : "$/.",
                        ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                        ImporteRow = Convert.ToDecimal(dr["montoTotal"]),

                    });
                }

                List<Dashboard> lstCH = new List<Dashboard>();
                lstCH.Add(lstCajaChica.Find(i => i.Codigoreporte == "TEGR0003"));
                if (lstCH[0] is null)
                {
                    lstCajaChica.Add(new Dashboard
                    {
                        Codigoreporte = "TEGR0003",
                        codAuxiliar = "",
                        Detallereporte = ConvertirPrimeraLetraMayuscula("Caja chica"),
                        Cantidad = 0,
                        idMoneda = Convert.ToInt32(1),
                        SimboloMoneda = "S/.",
                        ImporteTipoCambio = Convert.ToDecimal(0.20),
                        ImporteRow = Convert.ToDecimal(0)
                    });
                }
                
                if (clsBusq._cod1.Length > 5)
                {
                    DataView dvParatablas = new DataView(dtMenu.Tables[1]);


                    foreach (DataRowView dr in dvParatablas)
                    {
                        lsRepBloque.Add(new Dashboard
                        {
                            Codigoreporte = dr["id"].ToString(),
                            Detallereporte = ConvertirPrimeraLetraMayuscula(dr["descripcion"].ToString()),
                            Cantidad = Convert.ToInt32(dr["cantidad"]),
                            idMoneda = Convert.ToInt32(dr["idMoneda"]),
                            SimboloMoneda = dr["cSimbolo"].ToString(),
                            ImporteTipoCambio = Convert.ToDecimal(dr["cTipoCambio"]),
                            ImporteRow = Convert.ToDecimal(dr["montoTotal"])
                        });

                    }
                }
                

                return Tuple.Create(lsRepBloque,  lstCajaChica);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                
            }
        }
        public static string ConvertirPrimeraLetraMayuscula(string cadena)
        {            
            String dat= cadena.ToLower();

            if (string.IsNullOrEmpty(dat))
                return dat;

            string primeraLetraMayuscula = char.ToUpper(dat[0]) + dat.Substring(1);
            return primeraLetraMayuscula;
        }
    }
}

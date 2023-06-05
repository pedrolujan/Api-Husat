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
                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lst = null;
            }



        }
        public static string ConvertirPrimeraLetraMayuscula(string cadena)
        {
            cadena.ToLower();
            if (string.IsNullOrEmpty(cadena))
                return cadena;

            string primeraLetraMayuscula = char.ToUpper(cadena[0]) + cadena.Substring(1);
            return primeraLetraMayuscula;
        }
    }
}

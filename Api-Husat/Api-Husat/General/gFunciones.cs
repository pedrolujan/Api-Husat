using Api_Husat.Data;
using Api_Husat.Models;
using System.Data;

namespace Api_Husat.General
{
    public class gFunciones
    {
        public static List<Combobox> fnLlenarTablaCodTipoCon(String cCodTab, Boolean buscar)
        {
            daGeneral objTablaCod = new daGeneral();
            List<Combobox> lstTablaCod = new List<Combobox>();

            try
            {
                return objTablaCod.daDevolverTablaCodTipoCon(cCodTab, buscar);

                 
            }
            catch (Exception ex)
            {
                return lstTablaCod;
            }
            finally
            {
                lstTablaCod = null;
            }

        }

        public static List<Usuario> fnLlenarUsuariosConAccion(Boolean chk, DateTime dtIni, DateTime dtFin, Boolean estado,Int32 idUsuario)
        {
            daGeneral dc = new daGeneral();
            List<Usuario> lstUsuario = new List<Usuario>();
            DataTable dt = new DataTable();
            String FI = GetFechaHoraFormato(dtIni, 5);
            String FF = GetFechaHoraFormato(dtFin, 5);

            dt = dc.daDevolverSoloUsuario(chk, FI, FF, idUsuario);
            try
            {
                lstUsuario.Add(new Usuario(
                Convert.ToInt32(0),
                Convert.ToString(estado ? "TODOS" : "Selecc. Usuario")
              ));

                foreach (DataRow drMenu in dt.Rows)
                {
                    lstUsuario.Add(new Usuario(
                        Convert.ToInt32(drMenu["idUsuario"]),
                        Convert.ToString(drMenu["cUser"])
                        ));
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           return lstUsuario;


        }
        public static List<CajaChica> fnObtenerImporteCaja( DateTime dtFecha,Int32 idUsuario)
        {
            daGeneral dc = new daGeneral();
            List<CajaChica> lstImporte = new List<CajaChica>();
            DataTable dt = new DataTable();
            String FI = GetFechaHoraFormato(dtFecha, 5);

            lstImporte = dc.daObtenerImporteCaja( FI, idUsuario);
            
            
           return lstImporte;


        }

        public List<Consultas> blBuscarConsultas(String simcard, Int32 tipoCon)
        {
            daGeneral dc = new daGeneral();
            try
            {
                return dc.daBuscarConsultas(simcard, tipoCon);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public static List<Combobox> blLlenarCboSegunTablaTipoCon(String nomCampoId, String nomCampoNombre, String nomTabla, String nomEstado, String condicionDeEstado, Boolean buscar)
        {

            daGeneral objTablaCod = new daGeneral();
            try
            {
                return objTablaCod.daLlenarCboSegunTablaTipoCon(nomCampoId, nomCampoNombre, nomTabla, nomEstado, condicionDeEstado, buscar);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataSet BLCargarMenu(Int32 pstrUsuario, Int32 pintAplicacion)
        {
            daGeneral objTablaCod = new daGeneral();
            try
            {
                return objTablaCod.DACargarMenu(pstrUsuario, pintAplicacion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        public static String GetFechaHoraFormato(DateTime pdFecha, Int32 piFormato)
        {
            String sFecSis;
            String sDia, sMes, sAnio;
            String sHoraActual = (DateTime.Now.TimeOfDay.ToString());
            sFecSis = "";
            try
            {

                switch (piFormato)
                {
                    case 1:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio;
                        break;
                    case 5:       //Fecha corta              
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "/" + sMes + "/" + sDia;
                        break;
                    case 2:       //Registro en Base  FechaHora   
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + sMes + sDia + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 3:       //yyyy-mm-dd hh:mm:ss                         

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia;

                        sFecSis = sFecSis + " " + sHoraActual.Substring(0, 12);
                        break;
                    case 4:

                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sAnio + "-" + sMes + "-" + sDia + " " + pdFecha.Hour + ":" + pdFecha.Minute + ":" + pdFecha.Second + "." + pdFecha.Millisecond.ToString().PadLeft(3, '0');
                        break;
                    case 6:       //Presentación        dd//mm/yyyy           
                        sDia = pdFecha.Day.ToString();
                        sMes = pdFecha.Month.ToString();
                        sAnio = pdFecha.Year.ToString();

                        sDia = sDia.PadLeft(2, '0');
                        sMes = sMes.PadLeft(2, '0');

                        sFecSis = sDia + "/" + sMes + "/" + sAnio + " " + sHoraActual.Substring(0, 12); ;
                        break;
                }

                return sFecSis;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}

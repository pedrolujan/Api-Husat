using System.Data.SqlClient;
using System.Data;
using Api_Husat.Models;

namespace Api_Husat.Data
{
    public class daGeneral
    {
        public daGeneral() { }
        public List<Combobox> daDevolverTablaCodTipoCon(String cCodTab, Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtUsuario = new DataTable();
            Connection objCnx = null;

            try
            {

                pa[0] = new SqlParameter("@pecCodTab", SqlDbType.NVarChar, 8);
                pa[0].Value = cCodTab;


                objCnx = new Connection("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspListarTablaCod", pa);

                List<Combobox> lstCargo = new List<Combobox>();
                lstCargo.Add(new Combobox(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));

                foreach (DataRow drMenu in dtUsuario.Rows)
                {
                    lstCargo.Add(new Combobox(
                        Convert.ToString(drMenu["cCodTab"]),
                        Convert.ToString(drMenu["cNomTab"]),
                        Convert.ToString(drMenu["cValor"])));
                }

                return lstCargo;

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
            }

        }

        public DataTable daDevolverSoloUsuario(Boolean chk, String dtI, String dtFin, Int32 tipCOn)
        {
            SqlParameter[] pa = new SqlParameter[4];
            DataTable dtVehiculo = new DataTable();
            Connection objCnx = null;
            List<Usuario> lstUsuario = null;

            try
            {
                pa[0] = new SqlParameter("@dtInicio", SqlDbType.Date);
                pa[0].Value = dtI;
                pa[1] = new SqlParameter("@dtFin", SqlDbType.Date);
                pa[1].Value = dtFin;
                pa[2] = new SqlParameter("@chk", SqlDbType.Bit);
                pa[2].Value = chk;
                pa[3] = new SqlParameter("@tipoCOn", SqlDbType.Int);
                pa[3].Value = tipCOn;


                objCnx = new Connection("");
                dtVehiculo = objCnx.EjecutarProcedimientoDT("uspListarUsuariosConTrandiarias", pa);



                return dtVehiculo;

            }
            catch (Exception ex)
            {
                lstUsuario = null;
                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lstUsuario = null;
            }

        }
        public List<CajaChica> daObtenerImporteCaja(String dtFecha, Int32 idUsuario)
        {
            SqlParameter[] pa = new SqlParameter[2];
            DataTable dtResult = new DataTable();
            Connection objCnx = null;
            List<CajaChica> lstImporte = new List<CajaChica>(); ;

            try
            {
                pa[0] = new SqlParameter("@fechaActual", SqlDbType.Date);
                pa[0].Value = dtFecha;
                pa[1] = new SqlParameter("@idUsuario", SqlDbType.Int);
                pa[1].Value = idUsuario;


                objCnx = new Connection("");
                dtResult = objCnx.EjecutarProcedimientoDT("uspObtenerImporteEnCaja", pa);
                foreach (DataRow dt in dtResult.Rows)
                {
                    lstImporte.Add(new CajaChica
                    {
                        IdMoneda=1,
                        Usuario = dt["Usuario"].ToString(),
                        importe = Convert.ToDecimal(dt["ImporteCaja"])
                    });
                }


                return lstImporte;

            }
            catch (Exception ex)
            {
                lstImporte = null;
                
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCnx != null)
                    objCnx.CerrarConnection();
                objCnx = null;
                lstImporte = null;
            }

        }

        public DataSet DACargarMenu(Int32 pstrUsuario, Int32 pintAplicacion)
        {
            SqlParameter[] pa = new SqlParameter[2];
            Connection objCon = null;
            DataSet dtb = null;
            try
            {
                objCon = new Connection("");
                pa[0] = new SqlParameter("@peiUsuario", SqlDbType.Int);
                pa[0].Value = pstrUsuario;
                pa[1] = new SqlParameter("@peiAplicacion", SqlDbType.Int);
                pa[1].Value = pintAplicacion;

                dtb = objCon.EjecutarProcedimientoDS("uspObtenerMenu", pa);

                return dtb;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCon != null)
                    objCon.CerrarConnection();
                objCon = null;
                dtb = null;
            }


        }
        public List<Combobox> daLlenarCboSegunTablaTipoCon(String nomCampoId, String nomCampoNombre, String nomTabla, String nomEstado, String condicionDeEstado, Boolean buscar)
        {


            SqlParameter[] pa = new SqlParameter[5];
            DataTable dtUsuario = new DataTable();
            Connection objCnx = null;

            try
            {

                pa[0] = new SqlParameter("@id", SqlDbType.NVarChar, 80);
                pa[0].Value = nomCampoId;
                pa[1] = new SqlParameter("@nombre", SqlDbType.NVarChar, 80);
                pa[1].Value = nomCampoNombre;
                pa[2] = new SqlParameter("@tabla", SqlDbType.NVarChar, 1000);
                pa[2].Value = nomTabla;
                pa[3] = new SqlParameter("@estado", SqlDbType.NVarChar, 80);
                pa[3].Value = nomEstado;
                pa[4] = new SqlParameter("@conEstado", SqlDbType.NVarChar, 20);
                pa[4].Value = condicionDeEstado;


                objCnx = new Connection("");
                dtUsuario = objCnx.EjecutarProcedimientoDT("uspLlenarComboboxSegunTabla", pa);

                List<Combobox> lstCargo = new List<Combobox>();
                lstCargo.Add(new Combobox(
                        Convert.ToString("0"),
                        Convert.ToString(buscar ? "TODOS" : "Selecc. opcion"),
                        Convert.ToString("1")));
                if (nomCampoId == "CONSULTA")
                {
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstCargo.Add(new Combobox(
                            Convert.ToString(drMenu["id"]),
                            Convert.ToString(drMenu["nombre"]),
                            Convert.ToString(drMenu["estado"])));
                    }
                }
                else
                {
                    foreach (DataRow drMenu in dtUsuario.Rows)
                    {
                        lstCargo.Add(new Combobox(
                            Convert.ToString(drMenu["" + nomCampoId + ""]),
                            Convert.ToString(drMenu["" + nomCampoNombre + ""]),
                            Convert.ToString(drMenu["" + nomEstado + ""])));
                    }
                }


                return lstCargo;

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
            }

        }

    }
}

using Api_Husat.Models;
using System.Data.SqlClient;
using System.Data;

namespace Api_Husat.Data
{
    public class daPersonal
    {
        public Personal fnAccederSistema(String pcUsuario, String pcClave)
        {

            SqlParameter[] pa = new SqlParameter[4];
            Conection objCon = null;
            Int32 idAccede = 0;
            Int32 pnIdUsuario = 0;
            Personal personal = new Personal();
            try
            {

                objCon = new Conection("");

                pa[0] = new SqlParameter("@pecUsuario", SqlDbType.NVarChar, 20);
                pa[0].Value = pcUsuario;
                pa[1] = new SqlParameter("@pecClave", SqlDbType.VarChar, 20);
                pa[1].Value = pcClave;
                pa[2] = new SqlParameter("@psbAcceder", SqlDbType.SmallInt);
                pa[2].Direction = ParameterDirection.Output;
                pa[3] = new SqlParameter("@psiIdUsuario", SqlDbType.Int);
                pa[3].Direction = ParameterDirection.Output;

                objCon.EjecutarProcedimiento("uspAccederSistema", pa);
                idAccede = Convert.ToInt32(pa[2].Value);
                pnIdUsuario = Convert.ToInt32(pa[3].Value);

                if (idAccede == 1 && pnIdUsuario > 0)
                {
                    personal = daDevolverPersonal(pnIdUsuario);
                    personal.IdAcceso = idAccede;
                }
                else
                {
                    personal.IdAcceso = idAccede;
                }

                return personal;
            }
            catch (Exception ex)
            {
                //objUtil.gsLogAplicativo("DAAcceso.svc", "fnAccederSistema", ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objCon != null)
                    objCon.CerrarConnection();
                objCon = null;
            }

        }

        public Personal daDevolverPersonal(Int32 Usuario)
        {
            SqlParameter[] pa = new SqlParameter[1];
            DataTable dtVentaG = new DataTable();
            Conection objCnx = null;
            Personal cUsuario = new Personal();

            List<Personal> lstPersonal = new List<Personal>();
            try
            {
                pa[0] = new SqlParameter("@idUsuario", SqlDbType.TinyInt) { Value = Usuario };


                objCnx = new Conection("");
                dtVentaG = objCnx.EjecutarProcedimientoDT("uspObtenerUsuarioActual", pa);
                foreach (DataRow drMenu in dtVentaG.Rows)
                {
                    if (drMenu["Perfil"].ToString() == "")
                    {
                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                    }
                    else
                    {



                        byte[] b = (Byte[])drMenu["Perfil"];

                        cUsuario.idUsuario = Convert.ToInt32(drMenu["idUsuario"]);
                        cUsuario.idPersonal = Convert.ToInt32(drMenu["idPersonal"]);
                        cUsuario.cUsuario = Convert.ToString(drMenu["cUser"]);
                        cUsuario.cPrimerNom = Convert.ToString(drMenu["cPrimerNom"]);
                        cUsuario.cApePat = Convert.ToString(drMenu["cApePat"]);
                        cUsuario.cApeMat = Convert.ToString(drMenu["cApeMat"]);
                        cUsuario.cDireccion = Convert.ToString(drMenu["cDireccion"]);
                        cUsuario.cDocumento = Convert.ToString(drMenu["cDocumento"]);
                        cUsuario.codTema = Convert.ToString(drMenu["codTema"]);
                        cUsuario.btImgPerfil = b;
                    }
                }
                return cUsuario;
            }
            catch (Exception ex)
            {
                //objUtil.gsLogAplicativo("DACliente.cs", "daBuscarCliente", ex.Message);
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

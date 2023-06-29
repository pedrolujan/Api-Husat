using System.Data.SqlClient;
using System.Data;
using Api_Husat.Models;

namespace Api_Husat.Data
{
    public class daCliente
    {

        public List<Cliente> fnListarClientes(int _id, int _tipoCon)
        {
            List<Cliente> lstCliente = new List<Cliente>();
            Connection objConecta = null;
            objConecta = new Connection("");
            SqlParameter[] pa = new SqlParameter[2];
            try
            {
                pa[0] = new SqlParameter("@peidCliente", SqlDbType.Int) { Value = _id };
                pa[1] = new SqlParameter("@peTipoCon", SqlDbType.Int) { Value = _tipoCon };


                DataTable dataTable = new DataTable();

                dataTable = objConecta.EjecutarProcedimientoDT("uspListarCliente", pa);
                objConecta.CerrarConnection();
                foreach (DataRow d in dataTable.Rows)
                {
                    lstCliente.Add(new Cliente
                    {
                        Id = Convert.ToInt32(d["idCliente"]),
                        nombres = d["cNombre"].ToString(),
                        Edad = 25,
                        Celular = d["cTelCelular"].ToString()
                    });
                }
                return lstCliente;
            }
            catch (Exception ex)
            {

                return lstCliente;
            }
        }
    }
}

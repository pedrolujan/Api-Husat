using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Api_Husat.Data
{
    public class Conection
    {
        public SqlConnection sqlConnection;
        public SqlCommand command;
        public Conection() { }
        private int nTimeOut = 7200;
        public Conection(string sql)
        {
            String cadena = @"Initial Catalog=Husat; Data Source=DESKTOP-ROLGOA1\SQLEXPRESS; User ID=pruebas;Password=123456";
            sqlConnection = new SqlConnection(cadena);
            sqlConnection.Open();

        }
        public void CerrarConnection()
        {
            sqlConnection.Close();
        }
        public Int32 EjecutarProcedimiento(string storeProcedure, params object[] parameterValues)
        {

            Int32 nRowsAfec = 0;
            try
            {
                command = new SqlCommand(storeProcedure, sqlConnection);
                command.CommandTimeout = nTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                AssignParameterValues(command, parameterValues);

                nRowsAfec = command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return nRowsAfec;
        }
        public DataTable EjecutarProcedimientoDT(string storedProcedureName, params object[] parameterValues)
        {
            DataTable dtResultado = new DataTable();
            SqlDataAdapter da;
            try
            {

                command = new SqlCommand(storedProcedureName, sqlConnection);
                command.CommandTimeout = nTimeOut;
                command.CommandType = CommandType.StoredProcedure;
                if (parameterValues != null)
                {
                    AssignParameterValues(command, parameterValues);
                }

                da = new SqlDataAdapter(command);
                da.Fill(dtResultado);
                return dtResultado;
            }
            catch (Exception EX)
            {
                throw new Exception(EX.Message);
            }

        }
        void AssignParameterValues(DbCommand command, object[] values)
        {
            foreach (IDataParameter parameter in values)
            {
                command.Parameters.Add(parameter);
            }

        }
    }
}

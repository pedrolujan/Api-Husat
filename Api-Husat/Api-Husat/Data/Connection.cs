﻿using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Api_Husat.Data
{
    public class Connection
    {
        public SqlConnection sqlConnection;
        public SqlCommand command;
        public Connection() { }
        private int nTimeOut = 7200;
        public Connection(string sql)
        {
            String cadena = "";
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadena=constructor.GetSection("ConnectionStrings:conection").Value;

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
        public DataSet EjecutarProcedimientoDS(string storedProcedureName, params object[] parameterValues)
        {
            DataSet dsResultado = new DataSet();
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
                da.Fill(dsResultado);
                return dsResultado;
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

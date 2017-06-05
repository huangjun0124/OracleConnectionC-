using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace WinformVer
{
    public class OracleConnector
    {
        public static DataSet GetCommand(string sqlCommand)
        {
            OracleConnection connection = null;
            OracleDataAdapter oracleAdapter = null;
            OracleCommand oracleCommand = null;

            try
            {
                connection = OpenConn();
                oracleCommand = connection.CreateCommand();
                oracleCommand.CommandText = sqlCommand;
                oracleCommand.CommandType = CommandType.Text;

                oracleAdapter = new OracleDataAdapter();
                oracleAdapter.SelectCommand = oracleCommand;
                DataSet ds = new DataSet();
                oracleAdapter.Fill(ds);

                connection.Close();
                oracleAdapter.Dispose();
                oracleCommand.Dispose();
                connection.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                //UtilLog.LogError("OracleDAL.GetCommand throw exception. SQL Command[" + sqlCommand + "]");
                //UtilLog.LogError(ex.Message);
                //throw new FAB300Exception("M1300001#SQLCommand [" + sqlCommand+"]", ex);
                throw;
            }
            finally
            {
                if (oracleCommand != null)
                    oracleCommand.Dispose();
                if (oracleAdapter != null)
                    oracleAdapter.Dispose();
                if (connection != null)
                    connection.Dispose();
            }
        }

        private static OracleConnection OpenConn()
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.16.33)(PORT=1521))(CONNECT_DATA=(SID=keithtest)));Persist Security Info=True;User ID=keith;Password=keith;";
            conn.Open();
            return conn;
        }
    }
}

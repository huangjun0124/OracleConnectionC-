using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace OracleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection conn = null;
            try
            {
                conn = OpenConn();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from tb_users where  user_status = 1 and user_type = 'Junior'";
                cmd.CommandType = CommandType.Text;

                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);

                conn.Close();
                da.Dispose();
                cmd.Dispose();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConn(conn);
            }
        }


        static OracleConnection OpenConn()
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.220.16.33)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=keith)));Persist Security Info=True;User ID=keith;Password=keith;";
            conn.Open();
            return conn;
        }

        static void CloseConn(OracleConnection conn)
        {
            if (conn == null) { return; }
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}

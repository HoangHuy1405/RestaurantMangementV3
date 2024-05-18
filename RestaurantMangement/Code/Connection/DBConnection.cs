using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Connection
{
    public static class DBConnection
    {
        private static string connectionUrl = Properties.Settings.Default.connStr;

        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionUrl);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return conn;
        }

        public static void closeConnection(SqlConnection conn)
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                { 
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

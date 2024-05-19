using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{
    public class ManagerDAO
    {
        public static bool isManager(Account account)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
            string query = "Select mID from Manager " +
                           "where accID = '" + account.AccID + "'";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                string mId = (string)cmd.ExecuteScalar();

                if (string.IsNullOrEmpty(mId) ) 
                {
                    MessageBox.Show("Login as customer");
                    return false;
                }
                else
                {
                    MessageBox.Show("Login as admin");
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }

            return false;
        }
    }
}

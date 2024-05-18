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
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RMv7;Integrated Security=True; User ID = sa; Password = 123");
            //SqlConnection conn = Code.Connection.DBConnection.openConnection();
            string query = "Select mID from Manager " +
                           "where accID = '" + account.AccID + "'";
            try
            {
                string mId = "";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                var mIdVar = cmd.ExecuteScalar();
                if (mIdVar != null) {
                    mId = mIdVar.ToString();
                }

                if (string.IsNullOrEmpty(mId) ) 
                {
                    MessageBox.Show("Login as customer");
                    return true;
                }
                else
                {
                    MessageBox.Show("Login as admin");
                    return false;
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

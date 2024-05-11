using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantMangement.Code
{
    class Main
    {
        public static readonly string con_string = "Data Source = DESKTOP-6K73QJQ; Initial Catalog=RestaurantManagement; Persist Security Info=True; User ID = sa; Password = 123;";
        public static SqlConnection con = new SqlConnection(con_string);

        //Method to check user validation
        public bool isValidUser(string user, string password)
        {
            bool isValid = false;

            string query = @"Select * from users where username = '" + user + "' and upass = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

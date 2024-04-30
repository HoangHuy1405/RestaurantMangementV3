using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class DBConnection {
        // SqlConnection object to establish a connection with the database
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        // Method to load data from the database (ex: SELECT * FROM ...)
        public DataTable Load(string sqlStr) {
            try {
                // Open the database connection
                conn.Open();
                // Create a new SqlDataAdapter object to execute the SQL command and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                // Create a new DataTable to hold the retrieved data
                DataTable dt = new DataTable();
                // Fill the DataTable with data from the database
                adapter.Fill(dt);
                return dt;
            } catch (Exception exc) {
                // If an exception occurs, show the error message in a MessageBox
                MessageBox.Show(exc.Message);
            } finally {
                // Close the database connection in the finally block to ensure it is always closed
                conn.Close();
            }
            return new DataTable();
        }
        public void Execute(string sqlStr) {
            try {
                // Ket noi
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);

                if (cmd.ExecuteNonQuery() > 0) {

                } else {
                    MessageBox.Show("Unsuccessful");

                }
            } catch (Exception ex) {
                MessageBox.Show("Unsuccessful" + ex);
            } finally {
                conn.Close();
            }
        }
    }
}

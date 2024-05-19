using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{
    public class OrderDetailDAO 
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static OrderDetailDAO instance() {
            return new OrderDetailDAO();
        }
        public DataTable loadOrderDetailsFromOrderID(string orderID) {
            DataTable table = new DataTable();
            try {
                conn.Open();
                string query = "SELECT * " +
                               "FROM OrderDetail o" +
                               "JOIN Product p ON o.productID = p.productID" +
                               "WHERE orderID = '" + orderID + "'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(table);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
            }

            return table;
        }
    }
}

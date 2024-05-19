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

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                try {
                    conn.Open();
                    string query = "SELECT p.productID, p.productName, o.quantity, p.price " +
                                   "FROM OrderDetail o " +
                                   "JOIN Product p ON o.productID = p.productID " +
                                   "WHERE o.orderID = @orderID";

                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.Add(new SqlParameter("@orderID", orderID));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                            adapter.Fill(table);
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            if (table == null || table.Rows.Count == 0) {
                MessageBox.Show("No data found for the provided order ID.");
            }

            return table;
        }
    }
}

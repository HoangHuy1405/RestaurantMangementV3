using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace RestaurantMangement.Code.DAO
{
    public class OrderDAO  {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static OrderDAO instance() {
            return new OrderDAO();
        }
        public string insert(Order order) {
            string orderID = "";
            //SqlConnection conn = Code.Connection.DBConnection.openConnection();
            try {
                conn.Open();
                // Inserting the order and retrieving the generated orderID
                string query = "INSERT INTO [Orders] (date, totalPrice, accID) OUTPUT INSERTED.orderID VALUES (@date, @totalPrice, @accID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@date", order.Date);
                cmd.Parameters.AddWithValue("@totalPrice", order.TotalPrice);
                cmd.Parameters.AddWithValue("@accID", order.AccID);

                // Retrieve the generated orderID
                var orderIDObj = cmd.ExecuteScalar();
                if (orderIDObj != null) 
                    orderID = orderIDObj.ToString();

                // Inserting order details
                foreach (OrderDetail orderDetail in order.OrderList) {
                    string query2 = "INSERT INTO OrderDetail (quantity, productID, orderID) VALUES (@quantity, @productID, @orderID)";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    cmd2.Parameters.AddWithValue("@quantity", orderDetail.Quantity);
                    cmd2.Parameters.AddWithValue("@productID", orderDetail.ProductID);
                    cmd2.Parameters.AddWithValue("@orderID", orderID);

                    cmd2.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return orderID;
        }
        public void deleteOrder(string orderID) {
            try {
                conn.Open();
                // Inserting the order and retrieving the generated orderID
                string query = "DELETE FROM Orders WHERE orderID = '" + orderID + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                Code.Connection.DBConnection.closeConnection(conn);
            }
        }


    }
}

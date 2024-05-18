using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO {
    public class BillDAO {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RMv7;Integrated Security=True; User ID = sa; Password = 123");
        public static BillDAO instance() {
            return new BillDAO();
        }
        public string CreateBill(Bill bill) {
            string billID = "";
            try {
                conn.Open();

                string query = "INSERT INTO Bill " +
                               "(orderID, bookID, accID, voucherID, date, customerAddress, customerName, " +
                               "customerEmail, paymentMethods, status, note, totalPrice, type) " +
                               "OUTPUT INSERTED.billID " +
                               "VALUES " +
                               "(@OrderID,@BookId,@AccID,@VoucherID,@Date,@customerAddress,@CustomerName, " +
                               "@CustomerEmail,@PaymentMethod,@Status,@Note,@TotalPrice,@Type)";

                SqlCommand command = new SqlCommand(query, conn);

                // Add parameters
                command.Parameters.AddWithValue("@OrderID", string.IsNullOrEmpty(bill.OrderID) ? DBNull.Value : bill.OrderID);
                command.Parameters.AddWithValue("@BookId", string.IsNullOrEmpty(bill.BookedTableID) ? DBNull.Value : bill.BookedTableID);
                command.Parameters.AddWithValue("@AccID", bill.AccID);
                command.Parameters.AddWithValue("@VoucherID", string.IsNullOrEmpty(bill.VoucherId) ? DBNull.Value : bill.VoucherId);
                command.Parameters.AddWithValue("@Date", bill.Date);
                command.Parameters.AddWithValue("@customerAddress", bill.CustomerAddress);
                command.Parameters.AddWithValue("@CustomerName", bill.CustomerName);
                command.Parameters.AddWithValue("@CustomerEmail", bill.CustomerEmail);
                command.Parameters.AddWithValue("@CustomerPhone", bill.CustomerPhone);
                command.Parameters.AddWithValue("@PaymentMethod", bill.PaymentMethods); // Changed parameter name to match the stored procedure
                command.Parameters.AddWithValue("@Status", bill.Status);
                command.Parameters.AddWithValue("@Note", bill.Note);
                command.Parameters.AddWithValue("@TotalPrice", bill.TotalPrice);
                command.Parameters.AddWithValue("@Type", bill.Type);

                // Execute the command
                var billIDObj = command.ExecuteScalar();
                if (billIDObj != null)
                    billID = billIDObj.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return billID;
        }
    }
}

using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace RestaurantMangement.Code.DAO
{
    public class BookingDAO
    {
        private static SqlConnection conn = Code.Connection.DBConnection.getConnection();
        public static BookingDAO instance()
        {
            return new BookingDAO();
        }

        public string insert(Booking booking)
        {
            string bookingID = null;
            try
            {
                conn.Open();
                // Inserting the order and retrieving the generated orderID
                string query = "INSERT INTO Booking (totalPrice, timeBegin, timeEnd, accID, tableID) OUTPUT INSERTED.bookID " +
                                "VALUES (@totalPrice, @timeBegin, @timeEnd, @accID, @tableID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@totalPrice", booking.TotalPrice);
                cmd.Parameters.AddWithValue("@timeBegin",booking.TimeBegin);
                cmd.Parameters.AddWithValue("@timeEnd", booking.TimeEnd);
                cmd.Parameters.AddWithValue("@accID", booking.AccID);
                cmd.Parameters.AddWithValue("@tableID", booking.TableID);


                // Retrieve the generated orderID
                bookingID = (string)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return bookingID;
        }

    }
}

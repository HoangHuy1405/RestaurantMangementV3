using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace RestaurantMangement.Code.DAO
{
    public class BookingDAO
    {
        private static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
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

        public DataTable loadBookingInfor(string bookingID)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "select t.tableID, t.roomID, b.timeBegin, b.timeEnd " +
                               "from Booking b join [Table] t " +
                               "on b.tableID = t.tableID " +
                               "where b.bookID = '" + bookingID + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public void deleteBooking(string bookID) {
            try {
                conn.Open();
                string sqlQuery = "DELETE FROM Booking " +
                                  "WHERE bookID  = '" + bookID + "'";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
            }
        }
    }
}

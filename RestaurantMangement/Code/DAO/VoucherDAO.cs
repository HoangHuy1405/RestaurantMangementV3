using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMangement.Code.Model;

namespace RestaurantMangement.Code.DAO {
    public class VoucherDAO {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static VoucherDAO instance() {
            return new VoucherDAO();
        }
        public DataTable LoadVoucherTable() {
            DataTable dt = new DataTable();
            try {
                string sqlQuery = "SELECT * FROM Voucher";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                adapter.Fill(dt);
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
            return dt;
        }
        public void addVoucher(Voucher voucher) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string sqlQuery = string.Format("INSERT INTO Voucher(voucherName, Discount, exp_date) " +
                                                    "VALUES (@voucherName, @discount ,@exp_date)");

                    DataTable dt = new DataTable("Voucher");
                    DataRow row = dt.NewRow();

                    using (SqlCommand command = new SqlCommand(sqlQuery, conn)) {
                        command.Parameters.Add("@voucherName", SqlDbType.VarChar, 50).Value = voucher.VoucherName;
                        command.Parameters.Add("@discount", SqlDbType.Decimal, 4).Value = voucher.Discount;
                        command.Parameters.Add("@exp_date", SqlDbType.DateTime, 50).Value = voucher.Exp_date.ToString("yyyy-MM-dd HH:mm:ss");

                        command.ExecuteNonQuery();
                    }


                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
        public void editVoucher(Voucher voucher, string voucherID) {
            try {
                string query = "UPDATE Voucher " +
                               "SET voucherName = @VoucherName, discount = @Discount, exp_date = @ExpDate " +
                               "WHERE voucherID = @VoucherID";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr)) {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
                        command.Parameters.AddWithValue("@Discount", voucher.Discount);
                        command.Parameters.AddWithValue("@ExpDate", voucher.Exp_date);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
        public void deleteVoucher(string voucherID) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    string sqlQuery = "DELETE FROM Voucher " +
                                      "WHERE voucherID = '" + voucherID + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
    }
}

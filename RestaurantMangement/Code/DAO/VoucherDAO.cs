using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO {
    public class VoucherDAO {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RMv7;Integrated Security=True; User ID = sa; Password = 123");
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
    }
}

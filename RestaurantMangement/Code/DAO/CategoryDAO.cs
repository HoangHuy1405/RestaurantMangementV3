using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO {
    public class CategoryDAO {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static CategoryDAO instance() {
            return new CategoryDAO();
        }
        /* Category */
        public DataTable LoadCategoryTable() {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr)) {
                string query = "SELECT cateID, cateName FROM Category";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{
    public class ProductDAO
    {
        public static DataTable loadProductWithCate()
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = null;

            try
            {
                conn = Code.Connection.DBConnection.openConnection();

                string query = "SELECT p.ProductID, p.productName, p.description, p.price, c.cateName " +
                               "FROM Product p " +
                               "INNER JOIN category c ON p.cateID = c.cateID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dataTable);

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return dataTable;
        }
    }
}

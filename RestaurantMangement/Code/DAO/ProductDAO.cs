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
        static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static ProductDAO instance() {
            return new ProductDAO();
        }
        public DataTable loadProductWithCate()
        {
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();
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

        public void addProductWithCate(string productName, string description, double price, string cateName) {
            try {
                conn.Open();
                // PROCEDURE InsertProductWithCategory (in database)
                string sqlQuery = "DECLARE @cateID VARCHAR(4) " +
                                  "SELECT @cateID = cateID FROM category WHERE cateName = @cateName " +
                                  "IF @cateID IS NOT NULL " +
                                  "BEGIN " +
                                  "    INSERT INTO product (ProductName, description, price, cateID) " +
                                  "    VALUES (@productName, @description, @price, @cateID); " +
                                  "END";
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) {
                    // Parameters
                    command.Parameters.Add(new SqlParameter("@productName", productName));
                    command.Parameters.Add(new SqlParameter("@description", description));
                    command.Parameters.Add(new SqlParameter("@price", price));
                    command.Parameters.Add(new SqlParameter("@cateName", cateName));
                    command.ExecuteNonQuery();
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
        public string getCateIDFromCateName(string cateName) {
            string cateID = "";
            try {
                string sqlQuery = "SELECT cateID FROM Category WHERE cateName = '" + cateName + "'";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                conn.Open();
                cateID = command.ExecuteScalar().ToString();
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
            return cateID;
        }
        public void editProduct(string productID, string productName, string cateName, double price, string description) {
            string cateID = getCateIDFromCateName(cateName);
            // update product
            try {
                string query = "UPDATE Product " +
                               "SET productName = @ProductName, price = @Price, cateID = @CateID, description = @Description " +
                               "WHERE productID = @ProductID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@CateID", cateID);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@ProductID", productID);

                conn.Open();
                command.ExecuteNonQuery();
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }

        // delete product
        public void deleteProduct(string productID) {
            try {
                string query = "DELETE FROM Product WHERE ProductID = '" + productID + "'";
                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();
                command.ExecuteNonQuery();
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
    }
}

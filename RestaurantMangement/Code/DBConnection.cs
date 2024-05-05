using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RestaurantMangement.Code
{
    //
    internal class DBConnection
    {
        // SqlConnection object to establish a connection with the database
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public DBConnection() { }

        // Method to load data from the database (ex: SELECT * FROM ...)
        public DataTable Load(string sqlStr)
        {
            try
            {
                // Open the database connection
                conn.Open();
                // Create a new SqlDataAdapter object to execute the SQL command and fill the DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                // Create a new DataTable to hold the retrieved data
                DataTable dt = new DataTable();
                // Fill the DataTable with data from the database
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception exc)
            {
                // If an exception occurs, show the error message in a MessageBox
                MessageBox.Show(exc.Message);
            }
            finally
            {
                // Close the database connection in the finally block to ensure it is always closed
                conn.Close();
            }
            return new DataTable();
        }
        public void Execute(string sqlStr)
        {
            try
            {
                // Ket noi
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);

                if (cmd.ExecuteNonQuery() > 0)
                {

                }
                else
                {
                    MessageBox.Show("Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unsuccessful" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        /* ACCOUNT */
        public Account getCurrentUsingAccount(string email, string password) {
            Account user = null;
            try {
                conn.Open();
                string query = "SELECT * FROM Account WHERE email = @Email AND password = @Password";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        user = new Account {
                            AccId = reader["accID"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            FullName = reader["fullName"].ToString(),
                            Email = reader["email"].ToString(),
                            PhoneNum = reader["phoneNum"] != DBNull.Value ? reader["phoneNum"].ToString() : null,
                            Balance = reader["balance"] != DBNull.Value ? Convert.ToDouble(reader["balance"]) : 0.0
                        };
                    }
                }
                
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
            return user;
        }
        /* PRODUCT */
        public void addProductWithCate(string productName, string description, double price, string cataName)
        {
            try
            {
                conn.Open();
                // PROCEDURE InsertProductWithCategory (in database)
                using (SqlCommand command = new SqlCommand("InsertProductWithCategory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // Parameters
                    command.Parameters.AddWithValue("@productName", productName);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@cateName", cataName);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //edit
        private string GetOrCreateCategory(string cateName) {
            string cateID = "";
            try {
                string query = "SELECT cateID FROM Category WHERE CateName = @CateName";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@CateName", cateName);

                conn.Open();
                var result = command.ExecuteScalar();

                if (result != null) {
                    cateID = result.ToString();
                } else {
                    // if a category does not exist yet => create it
                    query = "INSERT INTO Category (cateName) VALUES (@CateName); SELECT SCOPE_IDENTITY();";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@CateName", cateName);

                    cateID = command.ExecuteScalar().ToString();
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }

            return cateID;
        }

        public void editProduct(string productID, string productName, string cateName, double price, string description) {
            string cateID = GetOrCreateCategory(cateName);
            // update product
            try {
                string query = "UPDATE Product SET productName = @ProductName, price = @Price, cateID = @CateID, description = @Description WHERE productID = @ProductID";
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
        public void deleteProduct(string productID)
        {
            try
            {
                string query = "DELETE FROM Product WHERE ProductID = '" + productID +"'";
                SqlCommand command = new SqlCommand(query, conn);

                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /* BILL */
        public void CreateBill(Bill bill) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string query = @"INSERT INTO bill (date, Address, customerName, customerEmail, 
                                                customerPhone, paymentMethods, Note, 
                                                total_price, accID, voucherID)
                             VALUES (@Date, @Address, @CustomerName, @CustomerEmail, 
                                     @CustomerPhone, @PaymentMethods, @Note, 
                                     @TotalPrice, @AccID, @VoucherID)";

                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.AddWithValue("@Date", bill.date);
                        command.Parameters.AddWithValue("@Address", bill.customerAddress);
                        command.Parameters.AddWithValue("@CustomerName", bill.customerName);
                        command.Parameters.AddWithValue("@CustomerEmail", bill.customerEmail);
                        command.Parameters.AddWithValue("@CustomerPhone", bill.customerPhone);
                        command.Parameters.AddWithValue("@PaymentMethods", bill.paymentMethods);
                        command.Parameters.AddWithValue("@Note", bill.note);
                        command.Parameters.AddWithValue("@TotalPrice", bill.totalPrice);
                        command.Parameters.AddWithValue("@AccID", bill.accId);
                        if (bill.voucherId == string.Empty) {
                            command.Parameters.AddWithValue("@VoucherID", DBNull.Value);
                        } else command.Parameters.AddWithValue("@VoucherID", bill.voucherId);

                        command.ExecuteNonQuery();
                    }
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }

            public void GetBillBasedOnBillID(Bill bill, string billid) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string query = "SELECT * FROM Bill WHERE billID = @BillID";

                    using (SqlCommand command = new SqlCommand(query, conn)) {
                        command.Parameters.AddWithValue("@BillID", billid);

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                bill.billId = reader["billID"].ToString();
                                bill.date = Convert.ToDateTime(reader["date"]);
                                bill.customerAddress = reader["Address"].ToString();
                                bill.customerName = reader["customerName"].ToString();
                                bill.customerEmail = reader["customerEmail"].ToString();
                                bill.customerPhone = reader["customerPhone"].ToString();
                                bill.paymentMethods = reader["paymentMethods"].ToString();
                                bill.note = reader["Note"].ToString();
                                bill.status = reader["status"].ToString();
                                bill.totalPrice = Convert.ToDecimal(reader["total_price"]);
                                bill.accId = reader["accID"].ToString();
                                bill.voucherId = reader["voucherID"].ToString();
                            }
                            reader.Close();
                        }
                    }
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }
        /* TABLE */
        public void LoadAvailableTable(string SQL, Guna2DataGridView gridview, DateTime tochoose)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@DateTime", tochoose);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridview.DataSource = dt;
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}

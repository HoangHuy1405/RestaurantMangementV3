using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace RestaurantMangement.Code
{
    //
    public class DBConnection
    {
        Account currentAcc = FResLogin.currentAcc;
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
        /* BILL */
        public void CreateBill(Bill bill) {
            using (var connection = new SqlConnection(Properties.Settings.Default.connStr)) {
                connection.Open();

                // Create a command for the stored procedure
                var command = new SqlCommand("CreateBill", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@Date", bill.Date);
                command.Parameters.AddWithValue("@Address", bill.CustomerAddress);
                command.Parameters.AddWithValue("@CustomerName", bill.CustomerName);
                command.Parameters.AddWithValue("@CustomerEmail", bill.CustomerEmail);
                command.Parameters.AddWithValue("@CustomerPhone", bill.CustomerPhone);
                command.Parameters.AddWithValue("@PaymentMethod", bill.PaymentMethods); // Changed parameter name to match the stored procedure
                command.Parameters.AddWithValue("@Note", bill.Note);
                command.Parameters.AddWithValue("@Status", bill.Status);
                command.Parameters.AddWithValue("@TotalPrice", bill.TotalPrice);
                command.Parameters.AddWithValue("@AccID", bill.AccId);
                command.Parameters.AddWithValue("@VoucherID", string.IsNullOrEmpty(bill.VoucherId) ? (object)DBNull.Value : bill.VoucherId);

                // Output parameter for BillID
                command.Parameters.Add("@BillID", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                // Parameter for BookedProducts using DataTable
                var bookedProductsTable = new DataTable();
                bookedProductsTable.Columns.Add("productID", typeof(string));
                bookedProductsTable.Columns.Add("quantity", typeof(int));

                foreach (var bookedProduct in bill.bookedProducts) {
                    bookedProductsTable.Rows.Add(bookedProduct.ProductId, bookedProduct.Quantity);
                }

                var parameter = command.Parameters.AddWithValue("@BookedProducts", bookedProductsTable);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.BookedProductType";

                // Execute the command
                command.ExecuteNonQuery();

                // Retrieve the output parameter value
                string billID = command.Parameters["@BillID"].Value.ToString();
                Console.WriteLine("Created bill with ID: " + billID);
            }
        }
        public string getBillIdBasedOnDate(string accID, DateTime date) {
            string billID = null;
            try {
                conn.Open();
                string sqlQuery = "SELECT billID FROM Bill WHERE accID = @AccID AND date = @Date";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) {
                    command.Parameters.AddWithValue("@AccID", accID);
                    command.Parameters.AddWithValue("@Date", date);

                    object result = command.ExecuteScalar();
                    if (result != null) {
                        billID = result.ToString();
                    }
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
            return billID;
        }


        public void GetBillBasedOnBillID(Bill bill, string billid) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM Bill WHERE billID = @BillID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, conn)) {
                        command.Parameters.AddWithValue("@BillID", billid);

                        using (SqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                bill.BillId = reader["billID"].ToString();
                                bill.Date = Convert.ToDateTime(reader["date"]);
                                bill.CustomerAddress = reader["Address"].ToString();
                                bill.CustomerName = reader["customerName"].ToString();
                                bill.CustomerEmail = reader["customerEmail"].ToString();
                                bill.CustomerPhone = reader["customerPhone"].ToString();
                                bill.PaymentMethods = reader["paymentMethods"].ToString();
                                bill.Note = reader["Note"].ToString();
                                bill.Status = reader["status"].ToString();
                                bill.TotalPrice = Convert.ToDecimal(reader["total_price"]);
                                bill.AccId = reader["accID"].ToString();
                                bill.VoucherId = reader["voucherID"].ToString();
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
        public DataTable GetBillHistoryFromDBOfThatAccount(string accId) {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM bill WHERE accID = '" + accId + "'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
            return dt;
        }
        /* TABLE */
        public DataTable LoadTablesFromDB() {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    string sqlQuery = "SELECT tableID, t.roomID, numchair, status, type, PricePerTable FROM [Table] t INNER JOIN Room r ON t.roomID = r.roomID";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
            return dt;
        }

        public string CheckTableAvailability(string timeBegin, string timeEnd, string roomType) {
            string tableID = "";
            string sqlQuery = @"SELECT t.tableID
                            FROM [Table] t
                            JOIN Room r ON t.roomID = r.roomID
                            WHERE r.type = @RoomType
                            AND t.tableID NOT IN
                            (
                                SELECT tableID
                                FROM AccBookTable
                                WHERE NOT
                                (
                                    timeEnd <= @TimeBegin
                                    OR timeBegin >= @TimeEnd
                                )
                            )
                         ";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr)) {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                    command.Parameters.AddWithValue("@TimeBegin", timeBegin);
                    command.Parameters.AddWithValue("@TimeEnd", timeEnd);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                        tableID = result.ToString();
                }
            }
            return tableID;
        }

        public BookedTable loadBookedTableFromTableID(string tableID) {
            BookedTable bookedTable = new BookedTable();

            string sqlQuery = @"
                            SELECT t.tableID, t.roomID, r.PricePerTable, r.type
                            FROM [Table] t
                            JOIN Room r ON t.roomID = r.roomID
                            WHERE t.tableID = '" + tableID + "'";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr)) {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                    command.Parameters.AddWithValue("@TableID", tableID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) {
                        bookedTable.TableID = tableID;
                        bookedTable.RoomID = reader["roomID"].ToString();
                        bookedTable.PricePerTable = Convert.ToDecimal(reader["PricePerTable"]);
                        bookedTable.RoomType = reader["type"].ToString();
                    }
                    reader.Close();
                }
            }

            return bookedTable;
        }

        public void InsertDataIntoAccBookTable(BookedTable bookedTable) {
            try {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr)) {
                    conn.Open();
                    MessageBox.Show(bookedTable.TimeBegin.ToString());
                    string sqlQuery = string.Format("INSERT INTO AccBookTable(tableID, accID, timeBegin, timeEnd) VALUES (@tableID, @accId ,@timeBegin, @timeEnd)");

                    DataTable dt = new DataTable("AccBookTable");
                    DataRow row = dt.NewRow();
                   
                    
                    using (SqlCommand command = new SqlCommand(sqlQuery, conn)) {
                        command.Parameters.Add("@tableID", System.Data.SqlDbType.VarChar, 4).Value = bookedTable.TableID;
                        command.Parameters.Add("@accId", System.Data.SqlDbType.VarChar, 4).Value = currentAcc.AccId;
                        command.Parameters.Add("@timeBegin", System.Data.SqlDbType.DateTime, 50).Value = bookedTable.TimeBegin.ToString("yyyy-MM-dd HH:mm:ss"); 
                        command.Parameters.Add("@timeEnd", System.Data.SqlDbType.DateTime, 50).Value = bookedTable.TimeEnd.ToString("yyyy-MM-dd HH:mm:ss"); 

                        
                        command.ExecuteNonQuery();
                    }

                    
                }
            } catch (SqlException ex) {
                MessageBox.Show("Error: " + ex.Message);
            } finally {
                conn.Close();
            }
        }

    }
}

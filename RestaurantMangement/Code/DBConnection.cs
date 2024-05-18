﻿using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using RestaurantMangement.Code.Model;
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
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RMv7;Integrated Security=True; User ID = sa; Password = 123");

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
 /*       public Account getCurrentUsingAccount(string email, string password)
        {
            Account user = null;
            try
            {
                conn.Open();
                string query = "SELECT * FROM Account WHERE email = @Email AND password = @Password";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new Account
                        {
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

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return user;
        }*/
        /* PRODUCT */
        public DataTable loadProductWithCate()
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                string query = "SELECT p.ProductID, p.productName, p.description, p.price, c.cateName " +
                               "FROM Product p " +
                               "INNER JOIN category c ON p.cateID = c.cateID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
        public void addProductWithCate(string productName, string description, double price, string cataName)
        {
            try
            {
                conn.Open();
                // PROCEDURE InsertProductWithCategory (in database)
                string sqlQuery = "DECLARE @cateID VARCHAR(4) " +
                                  "SELECT @cateID = cateID FROM category WHERE cateName = @cateName " +
                                  "INSERT INTO product (ProductName, description, price, cateID) " +
                                  "VALUES (@productName, @description, @price, @cateID)";
                using (SqlCommand command = new SqlCommand("sqlQuery", conn))
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
        private string GetOrCreateCategory(string cateName)
        {
            string cateID = "";
            try
            {
                string query = "SELECT cateID FROM Category WHERE CateName = @CateName";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@CateName", cateName);

                conn.Open();
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    cateID = result.ToString();
                }
                else
                {
                    // if a category does not exist yet => create it
                    query = "INSERT INTO Category (cateName) VALUES (@CateName); SELECT SCOPE_IDENTITY();";
                    command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@CateName", cateName);

                    cateID = command.ExecuteScalar().ToString();
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

            return cateID;
        }
        public string getCateIDFromCateName(string cateName)
        {
            string cateID = "";
            try
            {
                string sqlQuery = "SELECT cateID FROM Category WHERE cateName = '" + cateName + "'";
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                conn.Open();
                cateID = command.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return cateID;
        }

        public void editProduct(string productID, string productName, string cateName, double price, string description)
        {
            string cateID = getCateIDFromCateName(cateName);
            // update product
            try
            {
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
        // delete product
        public void deleteProduct(string productID)
        {
            try
            {
                string query = "DELETE FROM Product WHERE ProductID = '" + productID + "'";
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
        public DataTable LoadCategoryTable()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                string query = "SELECT cateID, cateName FROM Category";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
        /* BILL */
        public void CreateBill(Bill bill)
        {
            using (var connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                connection.Open();

                string query = "INSERT INTO Bill " +
                               "(orderID, bookID, accID, voucherID, date, customerAddress, customerName, " +
                               "customerEmail, paymentsMethods, status, note, totalPrice, type)" +
                               "VALUES " +
                               "(@OrderID,@BookId,@AccID,@VoucherID,@Date,@customerAddress,@CustomerName, " +
                               "@CustomerEmail,@PaymentMethod,@Status,@Note,@TotalPrice,@Type";

                var command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

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
                command.ExecuteNonQuery();

                // Retrieve the output parameter value
                string billID = command.Parameters["@BillID"].Value.ToString();
                Console.WriteLine("Created bill with ID: " + billID);
            }
        }

        // not work yet
        public string getBillIdBasedOnDate(string accID, DateTime date)
        {
            string billID = null;
            try
            {
                conn.Open();
                string sqlQuery = "SELECT billID FROM Bill WHERE accID = @AccID AND date = @Date";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {
                    command.Parameters.AddWithValue("@AccID", accID);
                    command.Parameters.AddWithValue("@Date", date);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        billID = result.ToString();
                    }
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
            return billID;
        }


/*        public void GetBillBasedOnBillID(Bill bill, string billid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM Bill WHERE billID = @BillID";

                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        command.Parameters.AddWithValue("@BillID", billid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
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
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }*/
        public DataTable GetBillHistoryFromDBOfThatAccount(string accId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM bill WHERE accID = '" + accId + "'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
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
            return dt;
        }
        public DataTable GetAllBillHistory()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM bill";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
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
            return dt;
        }
        public DataTable getBillFromBillID(string billID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM bill WHERE billID = '" + billID + "'";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
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
            return dt;
        }
        public void UpdateBillStatus(string billID, string billStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    string sqlQuery = "UPDATE Bill " +
                                      "SET status = '" + billStatus + "' " +
                                      "WHERE billID = '" + billID + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);
                    conn.Open();
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
        public void deleteBIll(string billID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    string sqlQuery = "DELETE FROM bill " +
                                      "WHERE billID = '" + billID + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    conn.Open();
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
        /* VOUCHER */
        public DataTable LoadVoucherTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    string sqlQuery = "SELECT * FROM Voucher";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
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
            return dt;
        }
        public void addVoucher(Voucher voucher)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = string.Format("INSERT INTO Voucher(voucherName, Discount, exp_date) " +
                                                    "VALUES (@voucherName, @discount ,@exp_date)");

                    DataTable dt = new DataTable("Voucher");
                    DataRow row = dt.NewRow();

                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        command.Parameters.Add("@voucherName", SqlDbType.VarChar, 50).Value = voucher.VoucherName;
                        command.Parameters.Add("@discount", SqlDbType.Decimal, 4).Value = voucher.Discount;
                        command.Parameters.Add("@exp_date", SqlDbType.DateTime, 50).Value = voucher.Exp_date.ToString("yyyy-MM-dd HH:mm:ss");

                        command.ExecuteNonQuery();
                    }


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
        public void editVoucher(Voucher voucher, string voucherID)
        {
            try
            {
                string query = "UPDATE Voucher " +
                               "SET voucherName = @VoucherName, discount = @Discount, exp_date = @ExpDate " +
                               "WHERE voucherID = @VoucherID";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VoucherID", voucherID);
                        command.Parameters.AddWithValue("@VoucherName", voucher.VoucherName);
                        command.Parameters.AddWithValue("@Discount", voucher.Discount);
                        command.Parameters.AddWithValue("@ExpDate", voucher.Exp_date);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
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
        public void deleteVoucher(string voucherID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    string sqlQuery = "DELETE FROM Voucher " +
                                      "WHERE voucherID = '" + voucherID + "'";
                    SqlCommand command = new SqlCommand(sqlQuery, conn);

                    conn.Open();
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
        /* TABLE */
        public DataTable LoadTablesFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    string sqlQuery = "SELECT tableID, t.roomID, numchair, status, type, PricePerTable " +
                                      "FROM [Table] t INNER JOIN Room r ON t.roomID = r.roomID";

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                    adapter.Fill(dt);
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
            return dt;
        }

        public string CheckTableAvailability(string timeBegin, string timeEnd, string roomType)
        {
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

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
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

        public BookedTable loadBookedTableFromTableID(string tableID)
        {
            BookedTable bookedTable = new BookedTable();

            string sqlQuery = @"
                            SELECT t.tableID, t.roomID, r.PricePerTable, r.type
                            FROM [Table] t
                            JOIN Room r ON t.roomID = r.roomID
                            WHERE t.tableID = '" + tableID + "'";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connStr))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
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

        /*public void InsertDataIntoAccBookTable(BookedTable bookedTable)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr))
                {
                    conn.Open();
                    MessageBox.Show(bookedTable.TimeBegin.ToString());
                    string sqlQuery = string.Format("INSERT INTO AccBookTable(tableID, accID, timeBegin, timeEnd) " +
                                                    "VALUES (@tableID, @accId ,@timeBegin, @timeEnd)");

                    DataTable dt = new DataTable("AccBookTable");
                    DataRow row = dt.NewRow();


                    using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                    {
                        command.Parameters.Add("@tableID", SqlDbType.VarChar, 4).Value = bookedTable.TableID;
                        command.Parameters.Add("@accId", SqlDbType.VarChar, 4).Value = currentAcc.AccId;
                        command.Parameters.Add("@timeBegin", SqlDbType.DateTime, 50).Value = bookedTable.TimeBegin.ToString("yyyy-MM-dd HH:mm:ss");
                        command.Parameters.Add("@timeEnd", SqlDbType.DateTime, 50).Value = bookedTable.TimeEnd.ToString("yyyy-MM-dd HH:mm:ss");


                        command.ExecuteNonQuery();
                    }


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
        }*/

    }
}

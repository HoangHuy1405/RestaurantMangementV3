using Guna.UI2.WinForms;
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
        //SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=RMv6;Integrated Security=True");

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
        

        
        
        /* BILL */
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
        
        /* VOUCHER */
        
        
        
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

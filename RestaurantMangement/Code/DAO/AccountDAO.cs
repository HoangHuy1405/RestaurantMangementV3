using RestaurantMangement.Code.Connection;
using RestaurantMangement.Code.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{   
    public class AccountDAO
    {
        // DAO - database access object
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public static AccountDAO instance() {
            return new AccountDAO();
        }

        public int insert(Account account)
        {
            int result = 0;
            //SqlConnection conn = Code.Connection.DBConnection.getConnection();
            try
            {
                conn.Open();
                string query = "Insert into Account " +
                               "(username, password, fullname, email, phoneNum, balance) " +
                               "values ('" + account.Username + "', '" + account.Password + "', '" + account.Fullname + "', '" + account.Email + "', '" + account.PhoneNum + "', '" + account.Balance + "')"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return result;
        }

        public int update(Account account)
        {
            throw new NotImplementedException();
        }

        public List<Account> selectAll()
        {
            throw new NotImplementedException();
        }

        public Account findbyUsernamePassword(Account account)
        {
            string query = "Select * from Account " +
                           "where username = '" + account.Username + "' and password ='" + account.Password + "'";
            try
            {   
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read()) 
                    {
                        string accID = reader.GetString(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);
                        string fullName = reader.GetString(3);
                        string email = reader.GetString(4);
                        string phoneNum = reader.GetString(5);
                        decimal balance = reader.GetDecimal(6);

                        account = new Account(accID, username, password, fullName, email, phoneNum, balance);
                        return account;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return null;
        }
        public bool CreateNewAccount(Account account)
        {
            if (checkUsernameExisted(account.Username) == true)
            {
                MessageBox.Show("Username has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                insert(account);
                return true;
            }
        }

        public Account selectByConditon(string query)
        {   
            Account account = null;
            //SqlConnection conn = Code.Connection.DBConnection.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {   
                    if (reader.Read()) 
                    {
                        string accID = reader.GetString(0);
                        string username = reader.GetString(1);
                        string password = reader.GetString(2);
                        string fullName = reader.GetString(3);
                        string email = reader.GetString(4);
                        string phoneNum = reader.GetString(5);
                        decimal balance = reader.GetDecimal(6);

                        account = new Account(accID, username, password, fullName, email, phoneNum, balance);
                        return account;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Code.Connection.DBConnection.closeConnection(conn);
            }
            return null;
        }

        private bool checkUsernameExisted(string username) 
        {
            string query = "Select * from Account " +
                           "where username = '" + username + "'";

            Account acc = selectByConditon(query);
            if (acc != null)
            {
                return true;
            }

            return false;

        }
        public void updateAccountBalance(decimal billPrice) {
            try {
                conn.Open();
                string query = "UPDATE Account SET balance = balance - @BillPrice WHERE accID = @AccID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@BillPrice", billPrice);
                command.Parameters.AddWithValue("@AccID", FResLogin.currentAcc.AccID);
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
            }
        }
        public decimal getAccountBalance() {
            decimal balance = 0m;
            try {
                conn.Open();
                string query = "SELECT balance FROM Account " +
                               "WHERE accID = @AccID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@AccID", FResLogin.currentAcc.AccID);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value) {
                    balance = (decimal)result;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                conn.Close();
            }
            return balance;
        }
    }
}

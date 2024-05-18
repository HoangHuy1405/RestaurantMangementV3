﻿using RestaurantMangement.Code.Connection;
using RestaurantMangement.Code.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.DAO
{   
    public class AccountDAO : DAOInterface<Account>
    {   
        public static AccountDAO instance() {
            return new AccountDAO();
        }

        public Account find(Account t)
        {
            throw new NotImplementedException();
        }

        public int delete(Account account)
        {
            throw new NotImplementedException();
        }

        public int insert(Account account)
        {
            int result = 0;
            SqlConnection conn = Code.Connection.DBConnection.openConnection();
            try
            {
                string query = "Insert into Account " +
                               "(username, password, fullname, email, phoneNum, balance) " +
                               "values '" + account.Username + "', '" + account.Password + "', '" + account.Fullname + "', '" + account.Email + "', '" + account.PhoneNum + "', '" + account.Balance + "')"; 
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
            SqlConnection conn = Code.Connection.DBConnection.openConnection();
            string query = "Select * from Account" +
                           "where username = '" + account.Username + "' and '" + account.Password + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
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
            SqlConnection conn = Code.Connection.DBConnection.openConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    string accID = reader.GetString(0);
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);
                    string fullName = reader.GetString(3);
                    string email = reader.GetString(4);
                    string phoneNum = reader.GetString(5);
                    float balance = reader.GetFloat(6);

                    account = new Account(accID, username, password, fullName, email, phoneNum, balance);
                    return account;
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
            string query = "Select * from Account" +
                           "where username = '" + username + "'";

            Account acc = selectByConditon(query);
            if (acc != null)
            {
                return true;
            }

            return false;

        }


    }
}
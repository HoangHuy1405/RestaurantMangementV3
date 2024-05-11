using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace RestaurantMangement.Code
{
    public class AccountDAO
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        private DBConnection dbconnection = new DBConnection();
        public bool CheckEmailExisted(string email)
        {
            string SQL = string.Format("SELECT * FROM Account WHERE email = '{0}'", email);
            DataTable dt = dbconnection.Load(SQL);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateNewAccount(Account account)
        {
            if (CheckEmailExisted(account.Email) == true)
            {
                MessageBox.Show("Email has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                string sql = string.Format("INSERT INTO Account (email, password, username, fullname) VALUES ('{0}', '{1}', '{2}', '{3}')", account.Email, account.Password, account.Username, account.FullName);
                dbconnection.Execute(sql);
                return true;
            }

        }
        public Account CheckAccount(Account account)
        {
            string SQL = string.Format("select * from Account where email = '{0}' and password = '{1}'", account.Email, account.Password);
            DataTable dt = dbconnection.Load(SQL);
            return GetAccountFromDataTable(dt);
        }
        public Account Retrieve(string accId)
        {
            string SQL = string.Format("SELECT * FROM Account WHERE accID = '{0}'", accId);
            DataTable dt = dbconnection.Load(SQL);
            return GetAccountFromDataTable(dt);
        }
        public Account GetAccountFromDataTable(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Account account = new Account();
                DataRow row = dt.Rows[0];
                account.AccId = Convert.ToString(row["accID"]);
                account.Username = Convert.ToString(row["username"]);
                account.Password = Convert.ToString(row["password"]);
                account.Email = Convert.ToString(row["email"]);
                account.PhoneNum = Convert.ToString(row["phoneNum"]);
                account.Balance = row["balance"] != DBNull.Value ? Convert.ToDouble(row["balance"]) : 0;

                //object birthdayValue = row["birthday"];
                //DateTime birthday;
                //if (birthdayValue != DBNull.Value && DateTime.TryParse(birthdayValue.ToString(), out birthday)) {
                //    account.Birthday = birthday;
                //}
                //// Assuming the Avatar column is stored as byte[] in the database
                //if (row["Avatar"] != DBNull.Value) {
                //    account.Avatar = (byte[])row["Avatar"];
                //} else {
                //    account.Avatar = null; // Or any other default value you want to assign
                //}
                return account;
            }
            else
            {
                return null;
            }
        }

        public bool checkManager(string accID)
        {
            string selectQuery = "Select mID from Manager where accID = '" + accID + "'";

            DataTable table = dbconnection.Load(selectQuery);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Admin");
                return true;
            }
            MessageBox.Show("Not admin");
            return false;
        }
    }
}

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

namespace RestaurantMangement {
    internal class AccountDAO {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        private DBConnection dbconnection = new DBConnection();
        public bool CheckEmailExisted(string email) {
            string SQL = string.Format("SELECT * FROM Account WHERE Email = '{0}'", email);
            DataTable dt = dbconnection.Load(SQL);

            if (dt.Rows.Count > 0) {
                return true;
            } else {
                return false;
            }
        }
        public bool CreateNewAccount(Account account) {
            if (CheckEmailExisted(account.Email) == true) {
                MessageBox.Show("Email has been existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } else {
                string sql = string.Format("INSERT INTO Account (Email, Password, Name) VALUES ('{0}', '{1}', '{2}')", account.Email, account.Password, account.Name);
                dbconnection.Execute(sql);
                return true;
            }

        }
        public Account CheckAccount(Account account) {
            string SQL = string.Format("select * from Account where Email = '{0}' and Password = '{1}'", account.Email, account.Password);
            DataTable dt = dbconnection.Load(SQL);
            return GetAccountFromDataTable(dt);
        }
        public Account Retrieve(int id) {
            string SQL = string.Format("SELECT * FROM Account WHERE ID = '{0}'", id);
            DataTable dt = dbconnection.Load(SQL);
            return GetAccountFromDataTable(dt);
        }
        public Account GetAccountFromDataTable(DataTable dt) {
            if (dt.Rows.Count > 0) {
                Account account = new Account();
                DataRow row = dt.Rows[0];
                account.Id = Convert.ToInt32(row["id"]);
                account.Name = Convert.ToString(row["name"]);
                account.Address = Convert.ToString(row["address"]);
                account.Email = Convert.ToString(row["email"]);
                account.Phone = Convert.ToString(row["phone"]);
                account.Password = Convert.ToString(row["password"]);
                account.Money = row["money"] != DBNull.Value ? Convert.ToDouble(row["money"]) : 0;

                object birthdayValue = row["birthday"];
                DateTime birthday;
                if (birthdayValue != DBNull.Value && DateTime.TryParse(birthdayValue.ToString(), out birthday)) {
                    account.Birthday = birthday;
                }
                // Assuming the Avatar column is stored as byte[] in the database
                if (row["Avatar"] != DBNull.Value) {
                    account.Avatar = (byte[])row["Avatar"];
                } else {
                    account.Avatar = null; // Or any other default value you want to assign
                }
                return account;
            } else {
                return null;
            }
        }
    }
}

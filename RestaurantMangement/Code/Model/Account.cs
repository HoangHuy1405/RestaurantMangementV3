using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Account
    {
        private string accID;
        private string username;
        private string password;
        private string fullname;
        private string email;
        private string phoneNum;
        private decimal balance;

        public Account() { }
        public Account(string accID, string username, string password, string fullname, string email, string phoneNum, decimal balance)
        {
            this.accID = accID;
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.email = email;
            this.phoneNum = phoneNum;
            this.balance = balance;
        }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Account(string username, string password, string fullname, string email, string phoneNum, decimal balance)
        {
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.email = email;
            this.phoneNum = phoneNum;
            this.balance = balance;
        }


        public string AccID { get => accID; set => accID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public decimal Balance { get => balance; set => balance = value; }
    }
}

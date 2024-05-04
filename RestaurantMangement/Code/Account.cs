using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code
{
    public class Account
    {
        private AccountDAO accountDAO = new AccountDAO();
        private string accId;
        private string username;
        private string password;
        private string fullName;
        private string email;
        private string phoneNum;
        private double balance;
        //private List<Recommend> recommendList = new List<Recommend>();
        private List<int> cancelledList = new List<int>();
        private List<int> savedList = new List<int>();
        private List<int> cartList = new List<int>();


        public Account()
        {
        }

        // used to check login
        public Account(string accId)
        {
            Account acc = accountDAO.Retrieve(accId);
            this.accId = acc.accId;
            email = acc.email;
            password = acc.password;
            fullName = acc.fullName;
            phoneNum = acc.phoneNum;
            balance = acc.balance;
            cancelledList = acc.cancelledList;
            savedList = acc.savedList;
            cartList = acc.cartList;
        }

        public Account(string accId, string username, string password, string fullName, string email, string phoneNum, double balance, List<int> cancelledList, List<int> savedList, List<int> cartList) : this(accId)
        {
            this.accId = accId;
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.email = email;
            this.phoneNum = phoneNum;
            this.balance = balance;
            this.cancelledList = cancelledList;
            this.savedList = savedList;
            this.cartList = cartList;
        }
        public Account(string username, string password, string fullName, string email, string phoneNum, double balance, List<int> cancelledList, List<int> savedList, List<int> cartList)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.email = email;
            this.phoneNum = phoneNum;
            this.balance = balance;
            this.cancelledList = cancelledList;
            this.savedList = savedList;
            this.cartList = cartList;
        }
        // used to sign up
        public Account(string username, string email, string password, string fullName)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.fullName = fullName;
            balance = 0;
        }
        // used to sign in 
        public Account(string email, string password)
        {
            this.email = email;
            this.password = password;
        }


        public string AccId { get => accId; set => accId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public double Balance { get => balance; set => balance = value; }
    }
}

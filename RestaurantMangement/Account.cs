using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class Account {
        private AccountDAO accountDAO = new AccountDAO();
        private int id;
        private string email;
        private string password;
        private string name;
        private string phone;
        private DateTime birthday;
        private string address;
        private double money;
        private byte[] avatar;
        //private List<Recommend> recommendList = new List<Recommend>();
        private List<int> cancelledList = new List<int>();
        private List<int> savedList = new List<int>();
        private List<int> cartList = new List<int>();

        public Account() {
        }

        public Account(int id) {
            Account acc = accountDAO.Retrieve(id);
            this.id = acc.id;
            this.email = acc.email;
            this.password = acc.password;
            this.name = acc.name;
            this.phone = acc.phone;
            this.birthday = acc.birthday;
            this.address = acc.address;
            this.money = acc.money;
            this.avatar = acc.avatar;
            this.cancelledList = acc.cancelledList;
            this.savedList = acc.savedList;
            this.cartList = acc.cartList;
        }

        public Account(int id, string email, string password, string name, string phone, DateTime birthday, string address, double money, byte[] avatar, List<int> cancelledList) {
            this.id = id;
            this.email = email;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.birthday = birthday;
            this.address = address;
            this.money = money;
            this.avatar = avatar;
            this.cancelledList = cancelledList;
            //this.savedList = savedList;
            //this.cartList = cartList;

        }

        public Account(string email, string password, string name, string phone, DateTime birthday, string address, byte[] avatar) {
            this.email = email;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.birthday = birthday;
            this.address = address;
            this.avatar = avatar;
        }
        public Account(string username, string email, string password) {
            this.name = username;
            this.email = email;
            this.password = password;
            money = 0;
        }
        public Account(string email, string password) {
            this.email = email;
            this.password = password;
        }



        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Address { get => address; set => address = value; }
        public byte[] Avatar { get => avatar; set => avatar = value; }
        public double Money { get => money; set => money = value; }
        public List<int> CancelledList { get => cancelledList; set => cancelledList = value; }
        public List<int> SavedList { get => savedList; set => savedList = value; }
        public List<int> CartList { get => cartList; set => cartList = value; }
    }
}

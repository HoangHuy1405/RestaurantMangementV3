using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class Product {
        private int productID;
        private string productName;
        private int categoryID;
        private double price = 0;
        private string description;
        private int quantity = 0;

        public Product(int productID, double price, int quantity) {
            this.productID = productID;
            this.price = price;
            this.quantity = quantity;
        }
        public Product(string productName, double price, string description, int quantity, int categoryID) {
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
        public Product(int productID, string productName, double price, string description, int categoryID) {
            this.productID = productID;
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
        }
        public Product(string productName, double price, string description, int categoryID) {
            this.productName = productName;
            this.price = price;
            this.description = description;
            this.categoryID = categoryID;
        }
        public Product(int productID, string productName, double price, string description, int quantity, int categoryID) {
            this.productID = productID;
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        private bool IsNull(string str) {
            return str.Length == 0;
        }
        public bool checkIfNotNull() {
            //if(IsNull(itemID)) {
            //    MessageBox.Show("Unvalid itemID");
            //    return false;
            //}
            if (IsNull(productName)) {
                MessageBox.Show("Unvalid itemName");
                return false;
            }
            return true;
        }
    }

}

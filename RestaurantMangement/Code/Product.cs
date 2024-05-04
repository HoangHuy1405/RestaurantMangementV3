using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code
{
    internal class Product
    {
        private string productID;
        private string productName;
        private string categoryID;
        private double price = 0;
        private string description;
        private int quantity = 0;

        public Product(string productID, double price, int quantity)
        {
            this.productID = productID;
            this.price = price;
            this.quantity = quantity;
        }
        public Product(string productName, double price, string description, int quantity, string categoryID)
        {
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
        public Product(string productID, string productName, double price, string description, string categoryID)
        {
            this.productID = productID;
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
        }
        public Product(string productName, double price, string description, string categoryID)
        {
            this.productName = productName;
            this.price = price;
            this.description = description;
            this.categoryID = categoryID;
        }
        public Product(string productID, string productName, double price, string description, int quantity, string categoryID)
        {
            this.productID = productID;
            this.productName = productName;
            this.categoryID = categoryID;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }

        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string CategoryID { get => categoryID; set => categoryID = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        private bool IsNull(string str)
        {
            return str.Length == 0;
        }
        public bool checkIfNotNull()
        {
            //if(IsNull(itemID)) {
            //    MessageBox.Show("Unvalid itemID");
            //    return false;
            //}
            if (IsNull(productName))
            {
                MessageBox.Show("Unvalid itemName");
                return false;
            }
            return true;
        }
    }

}

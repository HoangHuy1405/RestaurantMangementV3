using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Product
    {
        private string productID;
        private string productName;
        private decimal price;
        private string description;
        private string cateID;

        public Product(string productID, string productName, decimal price, string description, string cateID)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.description = description;
            this.cateID = cateID;
        }

        public string ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string CateID { get => cateID; set => cateID = value; }


        /*private bool IsNull(string str)
        {
            return str.Length == 0;
        }*/
        /*public bool checkIfNotNull()
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
        }*/
    }

}

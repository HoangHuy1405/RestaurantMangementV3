using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class MenuItem {
        private String itemID;
        private String itemName;
        private String type;
        private double price = 0;
        private String description;
        private int quantity = 0;

        public MenuItem(string itemName, string type, double price, string description, int quantity) {
            this.itemName = itemName;
            this.type = type;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
        public MenuItem(string itemID, string itemName, string type, double price, string description, int quantity) {
            this.itemID = itemID;
            this.ItemName = itemName;
            this.type = type;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }

        public string ItemID { get => itemID; set => itemID = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string Type { get => type; set => type = value; }
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
            if (IsNull(itemName)) {
                MessageBox.Show("Unvalid itemName");
                return false;
            }
            if (IsNull(type)) {
                MessageBox.Show("Unvalid type");
                return false;
            }
            return true;
        }
    }
}

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
        private String price;
        private String description;
        private String quantity;

        public MenuItem() { }
        public MenuItem(string itemID, string itemName, string type, string price, string description, string quantity) {
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
        public string Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Quantity { get => quantity; set => quantity = value; }
    }
}

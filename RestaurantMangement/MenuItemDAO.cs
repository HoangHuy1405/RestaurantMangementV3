using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement {
    internal class MenuItemDAO {
        protected SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        protected DBConnection db = new DBConnection();
        protected string tableName = "MenuItems";

        public DataTable load() {
            return db.Load("SELECT item_name, item_type, price, quantity FROM " + tableName);
        }
        public void add(MenuItem menuItem) {
            if (!menuItem.checkIfNotNull()) return;
            string sqlStr = string.Format("INSERT INTO {0} (item_name, item_type, price, description, quantity) VALUES ('{1}','{2}','{3}','{4}','{5}')", tableName, menuItem.ItemName, menuItem.Type, menuItem.Price, menuItem.Description, menuItem.Quantity);
            db.Execute(sqlStr);
        }
    }
}

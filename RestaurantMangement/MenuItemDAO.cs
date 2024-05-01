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

        public DataTable load() {
            return db.Load("SELECT item_name, item_type, price, quantity FROM MenuItems");
        }
    }
}

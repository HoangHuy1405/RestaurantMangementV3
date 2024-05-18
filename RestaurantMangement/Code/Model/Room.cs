using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Room
    {
        private string roomID;
        private string type;
        private decimal pricePerTable;
        private int maxTable;

        public Room() { }

        public Room(string roomID, string type)
        {
            this.roomID = roomID;
            this.type = type;
        }

        public Room(string roomID, string type, decimal pricePerTable, int maxTable)
        {
            this.roomID = roomID;
            this.type = type;
            this.pricePerTable = pricePerTable;
            this.maxTable = maxTable;
        }

        public string RoomID { get => roomID; set => roomID = value; }
        public string Type { get => type; set => type = value; }
        public decimal PricePerTable { get => pricePerTable; set => pricePerTable = value; }
        public int MaxTable { get => maxTable; set => maxTable = value; }
    }
}

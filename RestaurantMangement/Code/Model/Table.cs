using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Table
    {
        private string tableID;
        private int numchair;
        private string roomID;

        public Table(string tableID, int numchair, string roomID)
        {
            this.tableID = tableID;
            this.numchair = numchair;
            this.roomID = roomID;
        }

        public Table(int numchair, string roomID)
        {
            this.numchair = numchair;
            this.roomID = roomID;
        }

        public string TableID { get => tableID; set => tableID = value; }
        public int Numchair { get => numchair; set => numchair = value; }
        public string RoomID { get => roomID; set => roomID = value; }
    }
}

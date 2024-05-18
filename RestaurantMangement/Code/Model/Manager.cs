using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMangement.Code.Model
{
    public class Manager
    {
        private string mID;
        private string accID;
        public Manager() { }

        public Manager(string mID, string accID)
        {
            this.mID = mID;
            this.accID = accID;
        }

        public string MID { get => mID; set => mID = value; }
        public string AccID { get => accID; set => accID = value; }
    }
}

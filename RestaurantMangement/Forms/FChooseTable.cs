using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestaurantMangement.Code;

namespace RestaurantMangement.Forms
{
    public partial class FChooseTable : Form {

        public event EventHandler<FormClosedEventArgs> ChooseTableFormClosed;
        DateTime tochoose = new DateTime();
        DBConnection conn = new DBConnection();
        decimal totalMoney = 0;
        List<BookedTable> _bookedTable;

        public FChooseTable() {
            InitializeComponent();
        }

        private void FChooseTable_Load(object sender, EventArgs e) {
            string SQL = string.Format("SELECT * FROM dbo.GetAvailableTables(@DateTime)");
            conn.LoadAvailableTable(SQL, this.gvTable, tochoose);
            foreach (BookedTable bookedTable in _bookedTable) {
                // Find and remove rows with matching RoomID in gvTable
                foreach (DataGridViewRow row in gvTable.Rows) {
                    // Check if the cell and its value are not null before accessing
                    if (row.Cells["RoomID"] != null && row.Cells["RoomID"].Value != null) {
                        // Convert the value to string and compare
                        if (row.Cells["RoomID"].Value.ToString() == bookedTable.RoomID) {
                            gvTable.Rows.Remove(row);
                        }
                    }
                }
            }
        }
    }
}

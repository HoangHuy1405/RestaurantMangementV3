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
        DBConnection db = new DBConnection();
        decimal totalMoney = 0;
        List<BookedTable> _bookedTable;

        public FChooseTable() {
            InitializeComponent();
        }
        private void FChooseTable_Load(object sender, EventArgs e) {
            gvTable.DataSource = db.LoadTablesFromDB();
            gvTable.ColumnHeadersHeight = 30;
            gvChosenTable.ColumnHeadersHeight = 50;


        }

        private void gvTable_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0 && index >= 0) {
                // Get the selected row from gvTable
                DataGridViewRow selectedRow = gvTable.Rows[index];
                if (selectedRow.Cells["status"].Value.ToString() == "Occupied") {
                    MessageBox.Show("This table is already occupied!");
                    return;
                }

                string tableID = selectedRow.Cells[0].Value.ToString();
                string roomID = selectedRow.Cells[1].Value.ToString();
                int numberOfChairs = Convert.ToInt32(selectedRow.Cells[2].Value);

                string type = selectedRow.Cells[4].Value.ToString();
                decimal pricePerTable = Convert.ToDecimal(selectedRow.Cells[5].Value);
                // Calculate the subtotal for the new row
                decimal subtotal = Convert.ToDecimal(selectedRow.Cells[5].Value);

                // Update the total money
                totalMoney += subtotal;
                this.lblTotalMoney.Text = totalMoney.ToString();

                // Add the new row to gvChosenTable
                gvChosenTable.Rows.Add(tableID, roomID, numberOfChairs, type, pricePerTable);

                // Remove the selected row from gvTable
                gvTable.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void gvChosenTable_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0 && index < gvChosenTable.Rows.Count) {
                // Get the selected row from gvTable
                DataGridViewRow selectedRow = gvChosenTable.Rows[index];

                string tableID = selectedRow.Cells[0].Value.ToString();
                string roomID = selectedRow.Cells[1].Value.ToString();
                int numberOfChairs = Convert.ToInt32(selectedRow.Cells[2].Value);
                string status = "Available";
                string type = selectedRow.Cells[3].Value.ToString();
                decimal pricePerTable = Convert.ToDecimal(selectedRow.Cells[4].Value);

                // Get the underlying DataTable bound to gvTable
                DataTable table = (DataTable)gvTable.DataSource;
                // Add the new row to the chosen table data source
                DataRow newRow = table.NewRow();
                newRow["TableID"] = tableID;
                newRow["RoomID"] = roomID;
                newRow["Numchair"] = numberOfChairs;
                newRow["Status"] = status;
                newRow["Type"] = type;
                newRow["PricePerTable"] = pricePerTable;

                // Calculate the subtotal for the new row
                decimal subtotal = Convert.ToDecimal(selectedRow.Cells[4].Value);

                // Update the total money
                totalMoney -= subtotal;
                this.lblTotalMoney.Text = totalMoney.ToString();
                table.Rows.Add(newRow);

                // Remove the selected row from gvTable
                gvChosenTable.Rows.RemoveAt(index);
            }
        }
        public DataTable GetDataFromDataGridView() {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in gvChosenTable.Columns) {
                dt.Columns.Add(column.Name);
            }

            foreach (DataGridViewRow row in gvChosenTable.Rows) {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells) {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void btnService_Click(object sender, EventArgs e) {
            
        }

        private void btnGoBack_Click(object sender, EventArgs e) {
            DataTable dt = GetDataFromDataGridView();
            this.Hide();
            FChooseTable frm = new FChooseTable();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
    }
}

using RestaurantMangement.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms
{
    public partial class FResAddTable : Form {
        DBConnection db = new DBConnection();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        DataTable table = new DataTable("Rooms");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string roomID;

        public FResAddTable() {
            InitialAdapter();
            InitializeComponent();
        }
        private void InitialAdapter() {
            //select
            string selectQuery = "Select t.roomID, r.type, t.[Current table], r.MaximumTable as Rooms\r\nfrom\r\n\t(Select t.roomID, count(t.tableID) [Current Table]\r\n\tfrom \"Table\" t\r\n\tgroup by t.roomID)\r\n\tt inner join\r\n\t(\r\n\tSelect r.roomID, r.MaximumTable, r.type\r\n\tfrom Room r\r\n\t) r \r\non t.roomID = r.roomID";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
            adapter.SelectCommand = selectCmd;

            ds.Tables.Add(table);
        }
        private void LoadRoomsTable() {
            table.Rows.Clear();
            adapter.Fill(ds, "Rooms");
        }
        private void FResAddTable_Load(object sender, EventArgs e) {
            LoadRoomsTable();
            dgvRoom.DataSource = ds.Tables["Rooms"];
            ds.Tables.Add("Tables");
            dgvRoom.ColumnHeadersHeight = 30;
            dgvTable.ColumnHeadersHeight = 30;
        }
        private void showTables() {
            ds.Tables.Remove("Tables");
            string query = "Select t.tableID, t.numchair as Tables\r\nfrom \"Table\" t\r\nwhere roomID = '" + roomID + "'";
            adapter = new SqlDataAdapter();

            adapter.SelectCommand = new SqlCommand(query, conn);


            adapter.Fill(ds, "Tables");
            dgvTable.DataSource = ds.Tables["Tables"];
        }
        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0) {
                DataGridViewRow selectedRowofRows = dgvRoom.Rows[index];
                roomID = selectedRowofRows.Cells[0].Value.ToString();
                showTables();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            conn.Open();

            string query = "insert into \"Table\" (numchair, roomID) values (@numchair, @roomID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@numchair", SqlDbType.Int, 255).Value = txtNumberOfChair.Text.ToString();
            cmd.Parameters.Add("@roomID", SqlDbType.VarChar, 4).Value = roomID;
            cmd.ExecuteNonQuery();

            showTables();

            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e) {

        }

        private void btnDelete_Click(object sender, EventArgs e) {
            conn.Open();

            string query = "delete from \"Table\" (numchair, roomID) values (@numchair, @roomID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@numchair", SqlDbType.Int, 255).Value = txtNumberOfChair.Text.ToString();
            cmd.Parameters.Add("@roomID", SqlDbType.VarChar, 4).Value = roomID;
            cmd.ExecuteNonQuery();

            showTables();

            conn.Close();
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btnExit_Click(object sender, EventArgs e) {

        }
    }

}

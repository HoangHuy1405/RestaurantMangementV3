using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
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
    public partial class FResAddTable : Form
    {
        public FResAddTable()
        {
            InitializeComponent();
        }

        private void loadintoRoomBox()
        {
            DataTable tablewithRoomID = Code.DAO.RoomDAO.instance().getAllRoomID();
            if (tablewithRoomID.Rows.Count > 0)
            {
                foreach (DataRow row in tablewithRoomID.Rows)
                {
                    roomBox.Items.Add(row["roomID"].ToString());
                }
            }
        }

        private void FResAddTable_Load(object sender, EventArgs e)
        {
            //show dgvRoom
            DataTable table = Code.DAO.RoomDAO.instance().loadRoom();
            dgvRoom.DataSource = table;
            if (dgvRoom.Columns.Contains("roomID"))
                dgvRoom.Columns["roomID"].HeaderText = "Room Id";

            if (dgvRoom.Columns.Contains("Type"))
                dgvRoom.Columns["Type"].HeaderText = "Type";

            if (dgvRoom.Columns.Contains("pricePerTable"))
                dgvRoom.Columns["pricePerTable"].HeaderText = "Price per table";

            if (dgvRoom.Columns.Contains("Current Table"))
                dgvRoom.Columns["Current Table"].HeaderText = "Current Table";

            if (dgvRoom.Columns.Contains("maxTable"))
                dgvRoom.Columns["maxTable"].HeaderText = "Max table";

            dgvRoom.ColumnHeadersHeight = 30;
            dgvTable.ColumnHeadersHeight = 30;

            //show roomBox information
            roomBox.Items.Clear();
            loadintoRoomBox();
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTableID.Text = null;
            txtNumberOfChair.Text = null;

            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRowofRows = dgvRoom.Rows[index];
                string roomID = selectedRowofRows.Cells[0].Value.ToString();
                string roomType = selectedRowofRows.Cells[1].Value.ToString();
                string pricePerTable = selectedRowofRows.Cells[2].Value.ToString();

                txtRoomType.Text = roomType;
                roomBox.Text = roomID;
                txtPricePerTable.Text = pricePerTable;

                dgvTable.DataSource = Code.DAO.TableDAO.instance().loadTablebyRoom(roomID);
            }
        }

        private bool isFull(string roomID)
        {
            bool result = false;

            string query = "Select * " +
               "from Room " +
               "where roomID = '" + roomID + "'";

            Room room = Code.DAO.RoomDAO.instance().selectByConditon(query);
            int current_table = Code.DAO.TableDAO.instance().getCurrentTable(roomID);

            if (current_table >= room.MaxTable)
            {
                result = true;
            }
            return result;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            int numchairs = Convert.ToInt32(txtNumberOfChair.Text);
            string roomID = roomBox.Text.ToString();

            if (!isFull(roomID))
            {
                Table table = new Table(numchairs, roomID);
                if (Code.DAO.TableDAO.instance().insert(table) != 0)
                {
                    MessageBox.Show("Success.");
                    FResAddTable_Load(sender, e);
                    dgvTable.DataSource = Code.DAO.TableDAO.instance().loadTablebyRoom(roomID);

                }
                else
                {
                    MessageBox.Show("Fail.");
                }
            }
            else
            {
                MessageBox.Show("This room is full");
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tableID = txtTableID.Text;
            int numchairs = Convert.ToInt32(txtNumberOfChair.Text);
            string roomID = roomBox.Text.ToString();

            if (!isFull(roomID)) 
            {
                Table table = new Table(tableID, numchairs, roomID);

                if (Code.DAO.TableDAO.instance().update(table) != 0)
                {
                    MessageBox.Show("Success.");
                    FResAddTable_Load(sender, e);
                    dgvTable.DataSource = Code.DAO.TableDAO.instance().loadTablebyRoom(roomID);
                }
                else
                {
                    MessageBox.Show("Fail.");
                }
            }
            else
            {
                MessageBox.Show("The room you choose is full.");
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string tableID = txtTableID.Text;
            int numchairs = Convert.ToInt32(txtNumberOfChair.Text);
            string roomID = roomBox.Text.ToString();

            Table table = new Table(tableID, numchairs, roomID);

            if (Code.DAO.TableDAO.instance().delete(table) != 0)
            {
                MessageBox.Show("Success.");
                FResAddTable_Load(sender, e);
                dgvTable.DataSource = Code.DAO.TableDAO.instance().loadTablebyRoom(roomID);
            }
            else
            {
                MessageBox.Show("Fail.");
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRowofRows = dgvTable.Rows[index];
                string tableID = selectedRowofRows.Cells[0].Value.ToString();
                string numchairs = selectedRowofRows.Cells[1].Value.ToString();
                string roomID = selectedRowofRows.Cells[2].Value.ToString();

                txtTableID.Text = tableID;
                txtNumberOfChair.Text = numchairs.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FResBookingTable frm = new FResBookingTable();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }

        private void roomBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string roomID = roomBox.SelectedItem.ToString();

            string query = "Select * " +
                           "from Room " +
                           "where roomID = '" + roomID + "'";
            Room room = Code.DAO.RoomDAO.instance().selectByConditon(query);

            txtRoomType.Text = room.Type;
        }
    }

}

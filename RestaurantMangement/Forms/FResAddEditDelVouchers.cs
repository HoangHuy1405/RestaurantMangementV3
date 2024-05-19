using Guna.UI2.WinForms;
using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantMangement.Forms
{
    public partial class FResAddEditDelVouchers : Form {
        DBConnection db = new DBConnection();
        Voucher voucher = new Voucher();
        private decimal discount;
        public FResAddEditDelVouchers() {
            InitializeComponent();
        }

        private void FResAddEditDelVouchers_Load(object sender, EventArgs e) {
            DataTable dt = Code.DAO.VoucherDAO.instance().LoadVoucherTable();
            gvVoucher.DataSource = dt;

            if (gvVoucher.Columns.Contains("voucherID"))
                gvVoucher.Columns["voucherID"].HeaderText = "voucher ID";

            if (gvVoucher.Columns.Contains("voucherName"))
                gvVoucher.Columns["voucherName"].HeaderText = "Voucher Name";

            if (gvVoucher.Columns.Contains("discount"))
                gvVoucher.Columns["discount"].HeaderText = "Discount";

            if (gvVoucher.Columns.Contains("exp_date"))
                gvVoucher.Columns["exp_date"].HeaderText = "expired date";


            gvVoucher.ColumnHeadersHeight = 30;
        }


        private void gvVoucher_CellClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            if (index >= 0) {
                DataGridViewRow selectedRow = gvVoucher.Rows[index];
                txtVoucherID.Text = selectedRow.Cells[0].Value.ToString();
                txtVoucherName.Text = selectedRow.Cells[1].Value.ToString();
                txtVoucherDiscount.Text = selectedRow.Cells[2].Value.ToString();
                txtExpDate.Text = selectedRow.Cells[3].Value.ToString();
            }
        }
        private bool isValidDiscount() {
            if (decimal.TryParse(txtVoucherDiscount.Text, out discount)) {
                voucher.Discount = discount;
                return true;
            } else {
                MessageBox.Show("Invalid discount number!");
                return false;
            }
        }
        private bool isValidateDateTime() {
            string userInput = txtExpDate.Text;
            string format = "yyyy-MM-dd HH:mm:ss"; // Customize the format as per your requirement

            DateTime dateTime;
            if (DateTime.TryParseExact(userInput, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)) {
                voucher.Exp_date = dateTime;
                return true;
            } else {
                MessageBox.Show("Invalid DateTime!");
                return false;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            if (isValidDiscount() && isValidateDateTime()) {
                voucher.VoucherName = txtVoucherName.Text;
                Code.DAO.VoucherDAO.instance().addVoucher(voucher); 
                FResAddEditDelVouchers_Load(sender, e);
                MessageBox.Show("added successfully!");
                txtVoucherName.Text = "";
                txtExpDate.Text = "";
                txtVoucherDiscount.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (isValidDiscount() && isValidateDateTime()) {
                voucher.VoucherName = txtVoucherName.Text;
                Code.DAO.VoucherDAO.instance().editVoucher(voucher, txtVoucherID.Text);
                FResAddEditDelVouchers_Load(sender, e);
                MessageBox.Show("editted successfully!");
                txtVoucherName.Text = "";
                txtExpDate.Text = "";
                txtVoucherDiscount.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            Code.DAO.VoucherDAO.instance().deleteVoucher(txtVoucherID.Text);
            FResAddEditDelVouchers_Load(sender, e);
            MessageBox.Show("deleted successfully!");
            txtVoucherName.Text = "";
            txtExpDate.Text = "";
            txtVoucherDiscount.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Hide();
            FResOrder f = new FResOrder();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}

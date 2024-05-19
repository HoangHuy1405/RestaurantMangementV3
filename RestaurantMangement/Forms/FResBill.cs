using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMangement.Forms {
    public partial class FResBill : Form {
        Account currentAcc = FResLogin.currentAcc;
        Bill bill = new Bill();
        DBConnection db = new DBConnection();

        public FResBill() {
            InitializeComponent();
        }
        public FResBill(Bill bill) {
            InitializeComponent();
            this.bill = bill;
            Initilize();
        }
        private void FBill_Load(object sender, EventArgs e) {

        }
        private void Initilize() {
            lblBIllID.Text = bill.BillId;
            lblStatusFill.Text = bill.Status;
            lblNameFill.Text = bill.CustomerName;
            lblEmailFill.Text = bill.CustomerEmail;
            lblPhoneFill.Text = bill.CustomerPhone;
            lblAddressFill.Text = bill.CustomerAddress;
            lblDateFill.Text = bill.Date.ToString("yyyy-MM-dd HH:mm");
            lblPaymentFill.Text = bill.PaymentMethods;
            if (bill.VoucherId == null) {
                lblVoucherID.Text = "No voucher";
            } else {
                lblVoucherID.Text = bill.VoucherId;
            }
            lblTotalPriceFill.Text = bill.TotalPrice.ToString();
            //Fill for table cart
            DefiningBookedDishAndDrink();
        }
        private void DefiningBookedDishAndDrink() {
            dataGridView1.DataSource = Code.DAO.OrderDetailDAO.instance().loadOrderDetailsFromOrderID(bill.OrderID);
            dataGridView1.ColumnHeadersHeight = 30;
        }

        private void lblTotalPriceFill_Click(object sender, EventArgs e) {

        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            FBill_Load(sender, e);
        }

        private void btnHome_Click(object sender, EventArgs e) {
            this.Hide();
            FResMain f = new FResMain();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void lblBIllID_Click(object sender, EventArgs e) {

        }
    }
}

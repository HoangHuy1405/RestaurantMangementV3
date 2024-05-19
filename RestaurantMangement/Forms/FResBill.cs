using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;

namespace RestaurantMangement.Forms
{
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
            lblDateFill.Text = bill.Date.ToString("yyyy-MM-dd HH:mm");
            lblPaymentFill.Text = bill.PaymentMethods;
            lblTotalPriceFill.Text = bill.TotalPrice.ToString();

            if(bill.Type == "Booking")
            {
                lblVoucherID.Visible = false;
                lblVoucher.Visible = false;
                lblAddressFill.Visible = false;
                lblAddr.Visible = false;
            }
            else
            {
                lblAddressFill.Text = bill.CustomerAddress;
                if (string.IsNullOrEmpty(bill.VoucherId))
                {
                    lblVoucherID.Text = "No voucher";
                }
                else
                {
                    lblVoucherID.Text = bill.VoucherId;
                }
            }

            
            
            //Fill for table cart
            DefiningBookedDishAndDrink();
        }
        private void DefiningBookedDishAndDrink() {
            if (bill.Type == "Order Product")
            {
                dataGridView1.DataSource = Code.DAO.OrderDetailDAO.instance().loadOrderDetailsFromOrderID(bill.OrderID);
            }
            else
            {
                dataGridView1.DataSource = Code.DAO.BookingDAO.instance().loadBookingInfor(bill.BookedTableID);

            }
            dataGridView1.ColumnHeadersHeight = 30;
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
    }
}

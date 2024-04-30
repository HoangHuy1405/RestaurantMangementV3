using RestaurantMangement.Forms;

namespace RestaurantMangement {
    public partial class FResLogin : Form {
        AccountDAO accountDAO = new AccountDAO();
        public FResLogin() {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e) {

        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string email = txtEmail.Text.Trim();
            string password = txtPass.Text.Trim();
            if(string.IsNullOrEmpty(email) ) {
                MessageBox.Show("Email has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(string.IsNullOrEmpty (password) ) {
                MessageBox.Show("Password has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                Account acc = new Account(email, password);
                acc = accountDAO.CheckAccount(acc);
                if (acc == null) {
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Clear();
                    txtPass.Clear();
                } else {
                    // only hide the current form, not completely closed
                    this.Hide();
                    FResMain frm = new FResMain();
                    //This line attaches an event handler to the Closed event of the FOrderFood form.
                    //When FResMain form is closed, this event handler will be called, and it will close the current form (this.Close()).
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                }
            }
            
        }

        private void signUpBtn_Click(object sender, EventArgs e) {
            this.Hide();
            FResSignUp f = new FResSignUp();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}

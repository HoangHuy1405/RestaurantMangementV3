using RestaurantMangement.Forms;

namespace RestaurantMangement {
    public partial class FResLogin : Form {
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
            // create database and user table
            //if(Main.isValidUser(txtUser.Text, txtPass.Text) == false) {
            //    guna2MessageDialog1.Show("invalid username or password");
            //    return;
            //}
            //else {
            //    this.Hide();
            //    FResLogin frm = new FResLogin();
            //    frm.Show();
            //}

            // only hide the current form, not completely closed
            this.Hide();
            FResMain frm = new FResMain();
            //This line attaches an event handler to the Closed event of the FOrderFood form.
            //When FResMain form is closed, this event handler will be called, and it will close the current form (this.Close()).
            frm.Closed += (s, args) => this.Close();
            frm.Show();
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

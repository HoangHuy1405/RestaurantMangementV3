using RestaurantMangement.Code;
using RestaurantMangement.Code.Model;
using RestaurantMangement.Forms;
using System.DirectoryServices.ActiveDirectory;

namespace RestaurantMangement
{
    public partial class FResLogin : Form
    {
        public static Account currentAcc = new Account();
        public static bool isAdmin = false;
        public FResLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password has not been filled in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Account acc = new Account(username, password);
                acc = Code.DAO.AccountDAO.instance().findbyUsernamePassword(acc);
                if (acc == null)
                {
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPass.Clear();
                }
                else
                {
                    // get current using account to be used across project
                    currentAcc = acc;
                    isAdmin = Code.DAO.ManagerDAO.isManager(acc);

                    this.Hide();
                    FResMain frm = new FResMain();
                    frm.Closed += (s, args) => this.Close();
                    frm.Show();
                }
            }
        }
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FResSignUp f = new FResSignUp();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}

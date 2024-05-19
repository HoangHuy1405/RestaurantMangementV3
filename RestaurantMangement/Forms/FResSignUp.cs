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
using RestaurantMangement.Code.Model;

namespace RestaurantMangement.Forms
{
    public partial class FResSignUp : Form
    {
        public FResSignUp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string fullname = txtName.Text;
            string email = txtEmail.Text;
            string phonenum = txtPhonenum.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is empty.");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is empty.");
                return;
            }
            if (string.IsNullOrEmpty(fullname))
            {
                MessageBox.Show("Full name is empty.");
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is empty.");
                return;
            }
            if (string.IsNullOrEmpty(phonenum))
            {
                MessageBox.Show("Phone number is empty.");
                return;
            }

            Account acc = new Account(txtUser.Text, txtPass.Text, txtName.Text, txtEmail.Text, txtPhonenum.Text, 2000);
            if (Code.DAO.AccountDAO.instance().CreateNewAccount(acc))
            {
                MessageBox.Show("Account has been created successfully.", "Signup", MessageBoxButtons.OK);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FResLogin f = new FResLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}

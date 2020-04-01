using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users.BAL;

namespace UsrForm
{
    public partial class Existing : Form
    {
        public Existing()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String email = usr_email.Text.Trim();
            var res = UserBO.checkUserEmail(email);
            if (res==true)
            {
                Random _random = new Random();
                String code = _random.Next(0, 9999).ToString("D4");
                var result= UserBO.sendEmail(email, "Account Verification Code",code);
                if (result==true)
                {
                    this.Close();
                    ResetCode f = new ResetCode(code,email);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("There was an error.");
                }
            }
            else
            {
                emailErr.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = usr_login.Text.Trim();
            var pass = usr_password.Text.Trim();
            var result = UserBO.validateUser(login, pass);
            if (result== true)
            {
                this.Close();
                Welcome f = new Welcome(login);
                f.Show();
            }
            else
            {
                lblErrMsg.Visible = true;
            }
        }

        private void lblErrMsg_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}

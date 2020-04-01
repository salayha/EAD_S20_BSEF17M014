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
    public partial class ResetCode : Form
    {
        String code="";
        String email="";
        public ResetCode(String c, String e)
        {
            code = c;
            email = e;
            InitializeComponent();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            String userCode = usr_code.Text.Trim();
            if(userCode==code)
            {
                String login = UserBO.getUserLogin(email);
                ResetPassword f = new ResetPassword(login);
                this.Close();
                f.Show();
            }
            else
            {
                codeErr.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Existing f = new Existing();
            f.Show();
        }
    }
}

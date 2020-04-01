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
    public partial class ResetPassword : Form
    {
        String user="";
        public ResetPassword(String u)
        {
            user = u;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String passwd = usr_pass.Text.Trim();
            int result = UserBO.updatePassword(user, passwd);
            if (result!=-1)
            {
                this.Close();
                Welcome f = new Welcome(user);
                f.Show();
            }
            else
            {
                MessageBox.Show("There was an error.");
            }
        }
    }
}

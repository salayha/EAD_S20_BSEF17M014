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
    public partial class Welcome : Form
    {
        String name;
        public Welcome(String n)
        {
            name = n;
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            String image = UserBO.getUserImage(name);
            message.Text = "Welcome " + name;
            String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            String pathToSaveImage = applicationBasePath + @"\images\";
            String filepath = pathToSaveImage + image;
            myImage.Image = Image.FromFile(filepath);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            this.Close();
            newFrm f = new newFrm(name,false);
            f.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}

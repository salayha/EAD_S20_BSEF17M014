using Entities;
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
    
    public partial class @newFrm : Form
    {
        String user="";
        String image;
        public @newFrm(String caller)
        {
            if (caller!="")
            {
                user = caller;
            }
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
 
                    var result = openFileDialog1.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        var filepath = openFileDialog1.FileName;
                        usr_image.Image = Image.FromFile(filepath);

                    }
                }
            catch(Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user=="")
            {
                this.Close();
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                this.Close();
                Welcome f = new Welcome(user, image);
                f.Show();
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String uniqueName = "";
            if (usr_image.Image != null)
            {
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBasePath + @"\images\";
                uniqueName = Guid.NewGuid().ToString() + ".jpg";
                String imgPath = pathToSaveImage + uniqueName;
                usr_image.Image.Save(imgPath);
            }
            UserDTO dto = new UserDTO();
            dto.login = usr_login.Text.Trim();
            dto.password = usr_password.Text.Trim();
            dto.name = usr_name.Text.Trim();
            String gender = usr_gender.Text.Trim();
            if (gender == "Male")
            {
                dto.gender = 'M';
            }
            else
            {
                dto.gender = 'F';
            }
            dto.address = usr_address.Text.Trim();
            dto.age = Convert.ToInt32(usr_age.Value);
            dto.email = usr_email.Text.Trim();
            dto.NIC = usr_nic.Text.Trim();
            dto.DOB = Convert.ToDateTime(usr_dob.Value);
            dto.cricket = (usr_cricket.Checked == true ? "1" : "0");
            dto.hockey = (usr_hockey.Checked == true ? "1" : "0");
            dto.chess = (usr_chess.Checked == true ? "1" : "0");
            dto.image = uniqueName;
            dto.created = DateTime.Now;
            if (dto.name == "" || dto.login == "" || dto.password == "" || gender == "" || dto.address == "" || dto.NIC == "" || dto.DOB.ToString() == "" || dto.image == "")
            {
                emptyErr.Visible = true;
            }
            else if (dto.age <= 0)
            {
                AgeErr.Visible = true;
            }
            else
            {
                int result = UserBO.insertUser(dto);
                if (result == 1)
                {
                    user = dto.login;
                    image = dto.image;
                    this.Close();
                    Welcome f = new Welcome(user, image);
                    f.Show();

                }
                else if (result == -1)
                {
                    loginErr.Visible = true;
                }
                else
                {
                    MessageBox.Show("There was an error in db.");
                }
            }
        }

        private void newFrm_Load(object sender, EventArgs e)
        {
            if (user=="")
            {
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                System.IO.Directory.CreateDirectory(applicationBasePath + @"\images\");
            }
            else
            {
                UserDTO dto = UserBO.loadUser(user);
                usr_name.Text = dto.name;
                usr_login.Text = dto.login;
                if (dto.gender == 'M')
                {
                    usr_gender.Text = "Male";
                }
                else
                {
                    usr_gender.Text = "Female";
                }
                usr_password.Text = dto.password;
                usr_email.Text = dto.email;
                usr_address.Text = dto.address;
                usr_age.Value = dto.age;
                usr_nic.Text = dto.NIC;
                usr_dob.Value = dto.DOB;
                if (dto.cricket == "1")
                {
                    usr_cricket.Checked = true;
                    
                }
                else
                {
                    usr_cricket.Checked = false;
                }
                if (dto.hockey == "1")
                {
                    usr_hockey.Checked = true;
                }
                else
                {
                    usr_hockey.Checked = false;
                }
                if (dto.chess == "1")
                {
                    usr_chess.Checked = true;
                }
                else
                {
                    usr_chess.Checked = false;
                }
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBasePath + @"\images\";
                String filepath = pathToSaveImage + dto.image;
                usr_image.Image = Image.FromFile(filepath);
            }
            
        }
    }
}

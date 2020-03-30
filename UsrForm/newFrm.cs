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
                Welcome f = new Welcome(user);
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
            dto.NIC = user_nic.Text.Trim();
            dto.DOB = Convert.ToDateTime(usr_dob.Value);
            dto.cricket = (usr_cricket.Checked == true ? true : false);
            dto.hockey = (usr_hockey.Checked == true ? true : false);
            dto.chess = (usr_chess.Checked == true ? true : false);
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
            else if (UserBO.validateEmail(dto.email)!=true)
            {
                emailErr.Visible = true;
            }
            else
            {
                if (user=="")
                {
                    int result = UserBO.insertUser(dto);
                    if (result == 1)
                    {
                        user = dto.login;
                        this.Close();
                        Welcome f = new Welcome(user);
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
                else if (user!="")
                {
                    int result = UserBO.updateUser(dto);
                    if (result == 1)
                    {
                        user = dto.login;
                        this.Close();
                        Welcome f = new Welcome(user);
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
                usr_login.ReadOnly = true;
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
                user_nic.Text = dto.NIC;
                usr_dob.Value = dto.DOB;
                usr_cricket.Checked = dto.cricket;
                usr_hockey.Checked = dto.hockey;
                usr_chess.Checked = dto.chess;
                String applicationBasePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                String pathToSaveImage = applicationBasePath + @"\images\";
                String filepath = pathToSaveImage + dto.image;
                usr_image.Image = Image.FromFile(filepath);
                button1.Text = "Update";
            }
            
        }
    }
}

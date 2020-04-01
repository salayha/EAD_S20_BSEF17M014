namespace UsrForm
{
    partial class Existing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usr_login = new System.Windows.Forms.TextBox();
            this.usr_password = new System.Windows.Forms.TextBox();
            this.usr_email = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblErrMsg = new System.Windows.Forms.Label();
            this.emailErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(227, 135);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 2;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(318, 135);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Forgot Password?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Email";
            // 
            // usr_login
            // 
            this.usr_login.Location = new System.Drawing.Point(304, 42);
            this.usr_login.Name = "usr_login";
            this.usr_login.Size = new System.Drawing.Size(100, 20);
            this.usr_login.TabIndex = 6;
            // 
            // usr_password
            // 
            this.usr_password.Location = new System.Drawing.Point(304, 82);
            this.usr_password.Name = "usr_password";
            this.usr_password.Size = new System.Drawing.Size(100, 20);
            this.usr_password.TabIndex = 7;
            // 
            // usr_email
            // 
            this.usr_email.Location = new System.Drawing.Point(304, 210);
            this.usr_email.Name = "usr_email";
            this.usr_email.Size = new System.Drawing.Size(100, 20);
            this.usr_email.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(264, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Reset Password";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.AutoSize = true;
            this.lblErrMsg.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrMsg.Location = new System.Drawing.Point(236, 116);
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.Size = new System.Drawing.Size(140, 13);
            this.lblErrMsg.TabIndex = 10;
            this.lblErrMsg.Text = "Invalid Username/Password";
            this.lblErrMsg.Visible = false;
            this.lblErrMsg.Click += new System.EventHandler(this.lblErrMsg_Click);
            // 
            // emailErr
            // 
            this.emailErr.AutoSize = true;
            this.emailErr.ForeColor = System.Drawing.Color.Maroon;
            this.emailErr.Location = new System.Drawing.Point(301, 239);
            this.emailErr.Name = "emailErr";
            this.emailErr.Size = new System.Drawing.Size(66, 13);
            this.emailErr.TabIndex = 11;
            this.emailErr.Text = "Invalid Email";
            this.emailErr.Visible = false;
            // 
            // Existing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.emailErr);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.usr_email);
            this.Controls.Add(this.usr_password);
            this.Controls.Add(this.usr_login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Existing";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usr_login;
        private System.Windows.Forms.TextBox usr_password;
        private System.Windows.Forms.TextBox usr_email;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblErrMsg;
        private System.Windows.Forms.Label emailErr;
    }
}
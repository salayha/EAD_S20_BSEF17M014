namespace UsrForm
{
    partial class Welcome
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
            this.message = new System.Windows.Forms.Label();
            this.myImage = new System.Windows.Forms.PictureBox();
            this.edit = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myImage)).BeginInit();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(85, 59);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(35, 13);
            this.message.TabIndex = 0;
            this.message.Text = "label1";
            // 
            // myImage
            // 
            this.myImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myImage.Location = new System.Drawing.Point(444, 12);
            this.myImage.Name = "myImage";
            this.myImage.Size = new System.Drawing.Size(163, 149);
            this.myImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myImage.TabIndex = 1;
            this.myImage.TabStop = false;
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(444, 186);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(163, 37);
            this.edit.TabIndex = 2;
            this.edit.Text = "Edit Profile";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(444, 248);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(163, 33);
            this.logout.TabIndex = 3;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.myImage);
            this.Controls.Add(this.message);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.PictureBox myImage;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button logout;
    }
}
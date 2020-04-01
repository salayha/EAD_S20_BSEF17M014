namespace UsrForm
{
    partial class ResetCode
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
            this.label2 = new System.Windows.Forms.Label();
            this.usr_code = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.codeErr = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Code:";
            // 
            // usr_code
            // 
            this.usr_code.Location = new System.Drawing.Point(274, 76);
            this.usr_code.Name = "usr_code";
            this.usr_code.Size = new System.Drawing.Size(98, 20);
            this.usr_code.TabIndex = 2;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(261, 125);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(129, 42);
            this.confirm.TabIndex = 3;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // codeErr
            // 
            this.codeErr.AutoSize = true;
            this.codeErr.ForeColor = System.Drawing.Color.Maroon;
            this.codeErr.Location = new System.Drawing.Point(271, 99);
            this.codeErr.Name = "codeErr";
            this.codeErr.Size = new System.Drawing.Size(77, 13);
            this.codeErr.TabIndex = 4;
            this.codeErr.Text = "Incorrect Code";
            this.codeErr.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Change Email?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResetCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codeErr);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.usr_code);
            this.Controls.Add(this.label2);
            this.Name = "ResetCode";
            this.Text = "ResetCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usr_code;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label codeErr;
        private System.Windows.Forms.Button button1;
    }
}
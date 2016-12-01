namespace ElectronicSchoolDiary
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameWarning = new System.Windows.Forms.Label();
            this.PasswordWarning = new System.Windows.Forms.Label();
            this.InfoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.InfoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.LightBlue;
            this.PasswordTextBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.PasswordTextBox, "PasswordTextBox");
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            this.PasswordTextBox.MouseLeave += new System.EventHandler(this.PasswordTextBox_MouseLeave);
            this.PasswordTextBox.MouseHover += new System.EventHandler(this.PasswordTextBox_MouseHover);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.ForeColor = System.Drawing.Color.Black;
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.BackColor = System.Drawing.Color.LightBlue;
            this.UserNameTextBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.UserNameTextBox, "UserNameTextBox");
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.TextChanged += new System.EventHandler(this.UserNameTextBox_TextChanged);
            this.UserNameTextBox.MouseLeave += new System.EventHandler(this.UserNameTextBox_MouseLeave);
            this.UserNameTextBox.MouseHover += new System.EventHandler(this.UserNameTextBox_MouseHover);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // NameWarning
            // 
            resources.ApplyResources(this.NameWarning, "NameWarning");
            this.NameWarning.ForeColor = System.Drawing.Color.Red;
            this.NameWarning.Name = "NameWarning";
            // 
            // PasswordWarning
            // 
            resources.ApplyResources(this.PasswordWarning, "PasswordWarning");
            this.PasswordWarning.ForeColor = System.Drawing.Color.Red;
            this.PasswordWarning.Name = "PasswordWarning";
            // 
            // InfoPictureBox
            // 
            resources.ApplyResources(this.InfoPictureBox, "InfoPictureBox");
            this.InfoPictureBox.Name = "InfoPictureBox";
            this.InfoPictureBox.TabStop = false;
            this.InfoPictureBox.Click += new System.EventHandler(this.InfoPictureBox_Click);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.InfoPictureBox);
            this.Controls.Add(this.PasswordWarning);
            this.Controls.Add(this.NameWarning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameWarning;
        private System.Windows.Forms.Label PasswordWarning;
        private System.Windows.Forms.PictureBox InfoPictureBox;
    }
}


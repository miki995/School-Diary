
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using ElectronicSchoolDiary.Models;
using ElectronicSchoolDiary.Repos;

namespace ElectronicSchoolDiary
{
    public partial class LoginForm : Form
    {
        ToolTip toolTip1 = new ToolTip();
        string home = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()).ToString();

        public string GetHomeDirectory()
        {
            return home;
        }
     
        private void CapsWarning(TextBox box)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {

                toolTip1.ToolTipTitle = "Caps Lock je uključen";
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                toolTip1.IsBalloon = true;
                toolTip1.SetToolTip(box, "Ako je  Caps Lock uključen može prouzrokovati da unesete pogrešnu lozinku.\n\n Ako vasa lozinka sadrzi mala slova preporučljivo je da pritisnete Caps Lock  da ga isključite prije unošenja lozinke.");
                toolTip1.Show("Ako je  Caps Lock uključen može prouzrokovati da unesete pogrešnu lozinku.\n\n Ako vasa lozinka sadrzi mala slova preporučljivo je da pritisnete Caps Lock  da ga isključite prije unošenja lozinke.", box, 5, box.Height - 5);
            }
        }
     
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            UserNameTextBox.Text = "";
            PasswordTextBox.Text = ""; 
            UserNameTextBox.MouseHover += new EventHandler(UserNameTextBox_MouseHover);
            PasswordTextBox.MouseLeave += new EventHandler(UserNameTextBox_MouseLeave);

            UserNameTextBox.MouseHover += new EventHandler(PasswordTextBox_MouseHover);
            PasswordTextBox.MouseLeave += new EventHandler(PasswordTextBox_MouseLeave);

            CenterToParent();
            /*  Email email = new Email();
            email.SendEmailInBackground("miroslavmaksimovic95@gmail.com", "Miroslav", "password", "miki.maksimovic19995@gmail.com", "asd imamo izvjestaj");
*/
        }
    
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text.Length == 0 || PasswordTextBox.Text.Length == 0)
            {
                NameWarning.Show();
            }
            else { NameWarning.Hide(); }
            if (PasswordTextBox.Text.Length == 0)
            {
                PasswordWarning.Show();
            }
            else { PasswordWarning.Hide(); }
            Credentials r = new Credentials();
            r.CheckLogin(UserNameTextBox, PasswordTextBox);
            if (r.isNewFormOpened() == true)
            {
                UserNameTextBox.Text = "";
                PasswordTextBox.Text = "";
                this.Hide();
            }

        }
        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text.Length == 0) { NameWarning.Show(); } else { NameWarning.Hide(); }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text.Length == 0) { PasswordWarning.Show(); } else { PasswordWarning.Hide(); }

        }

        private void UserNameTextBox_MouseHover(object sender, EventArgs e)
        {
            CapsWarning(UserNameTextBox);
        }

        private void PasswordTextBox_MouseHover(object sender, EventArgs e)
        {
            CapsWarning(PasswordTextBox);
        }

        private void UserNameTextBox_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(UserNameTextBox);
        }

        private void PasswordTextBox_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(PasswordTextBox);
        }

        private void InfoPictureBox_Click(object sender, EventArgs e)
        {
            Form form = new AboutForm();
            form.Show();
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicSchoolDiary
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Form form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = new LoginForm();
            form.Show();
            this.Hide();
        }
    }
}

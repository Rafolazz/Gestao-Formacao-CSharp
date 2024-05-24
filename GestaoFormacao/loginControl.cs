using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormacao 
{
    public partial class loginControl : Form
    {
        public loginControl()
        {
            InitializeComponent();
        }

        private void IoginControl_Load(object sender, EventArgs e)
        {
            UC.UC_login uC_Login = new UC.UC_login();
            addUserControl(uC_Login);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }
    }
}

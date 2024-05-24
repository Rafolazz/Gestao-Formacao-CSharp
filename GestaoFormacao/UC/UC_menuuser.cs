using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_menuuser : UserControl
    {
        public UC_menuuser()
        {
            InitializeComponent();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Admin admin = this.ParentForm as Admin;
            admin.Close();
            loginControl loginControl = new loginControl();
            loginControl.Show();
        }

        private void UC_menuuser_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
    }
}

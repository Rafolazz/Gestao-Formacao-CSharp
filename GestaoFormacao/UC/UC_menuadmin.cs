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
    public partial class UC_menuadmin : UserControl
    {

        public UC_menuadmin()
        {
            InitializeComponent();
        }

        private void UC_menuadmin_Load(object sender, EventArgs e)
        {

        }
        public void home()
        {
            UC.UC_adminhome uC_Adminhome = new UC.UC_adminhome();
            addUserControl(uC_Adminhome);
        }
        private void addUserControl1(UserControl userControl)
        {
            Admin admin = this.ParentForm as Admin;
            userControl.BringToFront();
        }
        private void addUserControl(UserControl userControl)
        {
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            home();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC.UC_agenda af = new UC.UC_agenda();
            addUserControl(af);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC.UC_utilizadores uC_Utilizadores = new UC.UC_utilizadores();
            addUserControl(uC_Utilizadores);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Admin admin = this.ParentForm as Admin;
            admin.Close();
            loginControl loginControl = new loginControl();
            loginControl.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Admin admin = this.ParentForm as Admin;
            admin.Close();
            loginControl loginControl = new loginControl();
            loginControl.Show();
        }

        private void UC_menuadmin_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UC.UC_menumodulos uC_menumodulos = new UC.UC_menumodulos();
            addUserControl(uC_menumodulos);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            UC.UC_percursomenu uC_percursomenu = new UC.UC_percursomenu();
            addUserControl(uC_percursomenu);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC.UC_employees uC_employees = new UC.UC_employees();
            addUserControl(uC_employees);
        }
    }
}

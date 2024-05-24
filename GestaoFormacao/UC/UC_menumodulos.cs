using GestaoFormacao.Models;
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
    public partial class UC_menumodulos : UserControl
    {
        DataAccess db = new DataAccess();
        List<Models.Modulos> modulos = new List<Models.Modulos>();
        public UC_menumodulos()
        {
            InitializeComponent();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC.UC_modulos uc_modulos = new UC.UC_modulos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_modulos);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_agenda adm = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(adm);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            UC.UC_agenda adminformacao = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(adminformacao);
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            UC.UC_modulos uc_modulos = new UC.UC_modulos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_modulos);
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            modulos = db.SearchModule(guna2TextBox1.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                modulos = db.GetModules();
                guna2DataGridView2.DataSource = modulos;
            }
            else
            {
                guna2DataGridView2.DataSource = modulos;
                UpdateBinding();
            }
        }
        private void UpdateBinding()
        {
            guna2DataGridView2.Refresh();
        }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_menumodulos_Load(object sender, EventArgs e)
        {
            modulos = db.GetModules();
            guna2DataGridView2.DataSource = modulos;
            UpdateBinding();
        }
    }
}

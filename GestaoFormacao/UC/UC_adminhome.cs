using GestaoFormacao.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_adminhome : UserControl
    {
        DataAccess db = new DataAccess();
        List<Models.User> user = new List<Models.User>();
        List<Models.Funcionario> employee = new List<Models.Funcionario>();
        public UC_adminhome()
        {
            InitializeComponent();
        }
        private void UpdateBinding()
        {
            guna2DataGridView2.Refresh();
        }
        private void UC_adminhome_Load(object sender, EventArgs e)
        {
            user = db.GetUsers();
            guna2DataGridView2.DataSource = user;
            guna2DataGridView2.Columns["permissao"].Visible = false;
            guna2DataGridView2.Columns["palavrapasse"].Visible = false;
              UpdateBinding();
            guna2DataGridView2.Columns.Add("Módulos", "Módulos");

            employee = db.GetEmployee();
            guna2DataGridView1.DataSource = employee;
            guna2DataGridView2.Columns["permissao"].Visible = false;
            guna2DataGridView2.Columns["palavrapasse"].Visible = false;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC.UC_percursos uc_percursos = new UC.UC_percursos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_percursos);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC.UC_menumodulos uc_modulos = new UC.UC_menumodulos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_modulos);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC.UC_agenda uc_agenda = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_agenda);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

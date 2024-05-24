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
    public partial class UC_employees : UserControl
    {
        List<Models.Funcionario> funcionario = new List<Models.Funcionario>();
        DataAccess db = new DataAccess();
        public UC_employees()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_employeesadd uC_employeesadd = new UC.UC_employeesadd();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_employeesadd);
        }
        private void UpdateBinding()
        {
            guna2DataGridView1.Refresh();
        }
        private void UC_employees_Load(object sender, EventArgs e)
        {
            funcionario = db.GetEmployee();
            guna2DataGridView1.DataSource = funcionario;
            UpdateBinding();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            funcionario = db.SerchEmployee(guna2TextBox1.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                funcionario = db.GetEmployee();
                guna2DataGridView1.DataSource = funcionario;
            }
            else
            {
                guna2DataGridView1.DataSource = funcionario;
                UpdateBinding();
            }
        }
    }
}

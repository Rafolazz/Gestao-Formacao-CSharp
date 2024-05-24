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
    public partial class UC_employeesadd : UserControl
    {
        List<Models.User> user = new List<Models.User>();
        DataAccess db = new DataAccess();
        public UC_employeesadd()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC.UC_employees uC_employees = new UC.UC_employees();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_employees);
        }
        private void UpdateBinding()
        {
            guna2DataGridView1.Refresh();
        }
        private void UC_employeesadd_Load(object sender, EventArgs e)
        {
            user = db.GetEmployees();
            guna2DataGridView1.DataSource = user;
            guna2DataGridView1.Columns["palavrapasse"].Visible = false;
            guna2DataGridView1.Columns["funcionario"].Visible = false;
            guna2DataGridView1.Columns["ativo"].Visible = false;
            UpdateBinding();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            user = db.SerchNonEmployees(guna2TextBox1.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                user = db.GetEmployees();
                guna2DataGridView1.DataSource = user;
            }
            else
            {
                guna2DataGridView1.DataSource = user;
                UpdateBinding();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];
                var id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                db.AdicionarFuncionario(id, guna2ComboBox1.SelectedItem.ToString());
            }
            UC.UC_employees uC_employees = new UC.UC_employees();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_employees);
        }
    }
}

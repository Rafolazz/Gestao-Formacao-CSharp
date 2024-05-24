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
    public partial class UC_agenda : UserControl
    {
        DataAccess db = new DataAccess();
        List<Models.User> user = new List<Models.User>();
        public UC_agenda()
        {
            InitializeComponent();
        }
        private void UpdateBinding()
        {
            guna2DataGridView2.Refresh();
        }

        private void UC_agenda_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.Columns.Add("Hora", "Hora");
            guna2DataGridView1.Columns.Add("Utilizador", "Utilizador");
            for (int i = 0; i < 24; i++)
            {
                guna2DataGridView1.Rows.Add(i + ":00");
                guna2DataGridView1.Rows.Add(i + ":30");
            }
            user = db.GetUsers();
            guna2DataGridView2.DataSource = user;
            // guna2DataGridView2.Columns["Password"].Visible = false;
            // guna2DataGridView2.Columns["Permission"].Visible = false;
            UpdateBinding();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            user = db.SerchUser(guna2TextBox1.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                user = db.GetUsers();
                guna2DataGridView2.DataSource = user;
            }
            else
            {
                guna2DataGridView2.DataSource = user;
                UpdateBinding();
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UC.UC_agenda adm = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(adm);
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

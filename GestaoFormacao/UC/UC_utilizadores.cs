using GestaoFormacao.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_utilizadores : UserControl
    {
        List<Models.User> user = new List<Models.User>();
        DataAccess db = new DataAccess();

        public UC_utilizadores()
        {
            InitializeComponent();
        }

        private void UpdateBinding()
        {
            guna2DataGridView1.Refresh();
        }

        private void UC_utilizadores_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            user = db.GetUsers();
            guna2DataGridView1.DataSource = user;

            // Hide irrelevant columns
            guna2DataGridView1.Columns["palavrapasse"].Visible = false;
            guna2DataGridView1.Columns["funcionario"].Visible = false;
            guna2DataGridView1.Columns["ativo"].Visible = false;
            guna2DataGridView1.Columns["permissao"].Visible = false;

            // Add "perms" column if it does not exist
            if (!guna2DataGridView1.Columns.Contains("perms"))
            {
                guna2DataGridView1.Columns.Add("perms", "Permissão");
            }

            // Populate the "perms" column based on "permissao"
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["permissao"].Value != null)
                {
                    if (int.TryParse(row.Cells["permissao"].Value.ToString(), out int permissao))
                    {
                        row.Cells["perms"].Value = permissao == 1 ? "Admin" : "User";
                    }
                }
            }
            UpdateBinding(); // Refresh the DataGridView to show updates
        }

        private void PerformSearch()
        {
            user = db.SerchUser(guna2TextBox1.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text))
            {
                user = db.GetUsers();
            }
            guna2DataGridView1.DataSource = user;
            LoadUsers(); // Ensure the "perms" column is updated after search
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC.UC_adduser uC_Adduser = new UC.UC_adduser();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_Adduser);
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click event if necessary
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if necessary
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_adduser uC_Adduser = new UC.UC_adduser();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_Adduser);
        }

        private void guna2DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content double-click event if necessary
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["id"].Value);
                UC.UC_useredit uc_useredit = new UC.UC_useredit(id);
                Admin admin = this.ParentForm as Admin;
                admin.panel3.Controls.Clear();
                admin.panel3.Controls.Add(uc_useredit);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Handle pictureBox3 click event if necessary
        }
    }
}
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
    public partial class UC_percursomenu : UserControl
    {
        public UC_percursomenu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_agenda adminformacao = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(adminformacao);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC.UC_percursos uc_percursos = new UC.UC_percursos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uc_percursos);
        }
        DataAccess db = new DataAccess();

        private void UC_percursomenu_Load(object sender, EventArgs e)
        {
            guna2DataGridView2.DataSource = db.GetPercurso();
            guna2DataGridView2.Refresh();
        }
    }
}

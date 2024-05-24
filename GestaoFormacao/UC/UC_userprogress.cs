using Guna.UI2.WinForms;
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
    public partial class UC_userprogress : UserControl
    {
        private int userId;
        private Models.User user;
        private DataAccess db = new DataAccess();
        public UC_userprogress(int id)
        {
            InitializeComponent();
            this.userId = id;
        }

        private void UC_userprogress_Load(object sender, EventArgs e)
        {
            user = db.GetUserById(userId);

            guna2TextBox1.Text = user.nome;
            guna2TextBox4.Text = user.email;

            guna2DataGridView1.Columns.Add("Percurso", "Percurso");
            guna2DataGridView1.Columns.Add("Módulos", "Módulos");
            for (int i = 0; i < 10; i++)
            {
                guna2DataGridView1.Rows.Add("Percurso","Módulo");
            }

            guna2ProgressBar1.Value = 50;
            int percentagem = (int)(((double)guna2ProgressBar1.Value / (double)guna2ProgressBar1.Maximum) * 100);
            label4.Text = percentagem.ToString() + "%";
        }
        public class DataGridViewProgressBarCell : DataGridViewTextBoxCell
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UC.UC_agenda adm = new UC.UC_agenda();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(adm);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            int percentagem = (int)(((double)guna2ProgressBar1.Value / (double)guna2ProgressBar1.Maximum) * 100);
            label4.Text = percentagem.ToString() + "%";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

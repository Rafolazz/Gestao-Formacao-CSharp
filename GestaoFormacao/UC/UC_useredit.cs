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
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_useredit : UserControl
    {
        private int userId;
        private Models.User user;
        private DataAccess db = new DataAccess();

        public UC_useredit(int id)
        {
            InitializeComponent();
            this.userId = id;
        }

        private void UC_useredit_Load(object sender, EventArgs e)
        {
            user = db.GetUserById(userId);

            guna2TextBox1.Text = user.nome;
            guna2TextBox4.Text = user.email;
            guna2ComboBox1.SelectedItem = user.permissao.ToString();
            guna2ComboBox1.SelectedItem = user.ativo.ToString();

            if (user.permissao == 1)
            {
                guna2ComboBox1.Text = "Admin";
            }
            else
            {
                guna2ComboBox1.Text = "User";
            }
            if (user.ativo == 1)
            {
                guna2ComboBox2.Text = "Ativo";
            }
            else
            {
                guna2ComboBox2.Text = "Inativo";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int perm = guna2ComboBox1.SelectedItem.ToString().ToLower() == "admin" ? 1 : 0;
            int ativo = guna2ComboBox2.SelectedItem.ToString().ToLower() == "ativo" ? 1 : 0;
            db.UpdateUserPermission(userId, perm, ativo);
            UC.UC_utilizadores uC_Utilizadores = new UC.UC_utilizadores();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_Utilizadores);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC.UC_utilizadores uC_Utilizadores = new UC.UC_utilizadores();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_Utilizadores);
        }
    }
}

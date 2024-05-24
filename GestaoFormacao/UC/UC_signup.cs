using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_signup : UserControl
    {
        DataAccess db = new DataAccess();
        public UC_signup()
        {
            InitializeComponent();
        }

        public void UC_signup_Load(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
            guna2TextBox3.UseSystemPasswordChar = true;
        }
            public static Random Random = new Random();
            public static string code = Random.Next(100000, 999999).ToString();
            public static string guna1;
            public static string guna4;
            public static string guna2;

        private bool IsValidPassword(string password)
        {
            if (password.Length < 6) return false;
            if (!password.Any(char.IsDigit)) return false;
            if (!password.Any(char.IsUpper)) return false;
            if (!password.Any(char.IsLower)) return false;

            return true;
        }


        public void log()
        {
            UC_login uC_login = new UC_login();
            loginControl lc = this.ParentForm as loginControl;
            lc.panel1.Controls.Clear();
            lc.panel1.Controls.Add(uC_login);
        }
        public void guna2Button3_Click(object sender, EventArgs e)
        {
            log();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.UseSystemPasswordChar == true)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GestaoFormacao", "GestaoFormacao", "ico", "eye-solid.png"));
                guna2TextBox2.UseSystemPasswordChar = false;
                guna2TextBox3.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GestaoFormacao", "GestaoFormacao", "ico", "eye-slash-solid.png"));
                guna2TextBox2.UseSystemPasswordChar = true;
                guna2TextBox3.UseSystemPasswordChar = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!db.checkEmail(guna2TextBox4.Text))
                {
                    return;
                }

                string password = guna2TextBox2.Text;
                if (password != guna2TextBox3.Text)
                {
                    MessageBox.Show("As palavras-pass não coincidem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidPassword(password))
                {
                    MessageBox.Show("A senha é fraca. A senha deve ter pelo menos 6 caracteres, incluindo pelo menos 1 dígito e 1 letra maiúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                guna1 = guna2TextBox1.Text;
                guna2 = password;
                guna4 = guna2TextBox4.Text;

                Functions.SendEmail(guna2TextBox4.Text, "Code", code);

                UC_codeverify uC_Codeverify = new UC_codeverify();
                loginControl lc = this.ParentForm as loginControl;
                if (lc != null)
                {
                    lc.panel1.Controls.Clear();
                    lc.panel1.Controls.Add(uC_Codeverify);
                }
                else
                {
                    MessageBox.Show("Failed to cast ParentForm to loginControl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_login : UserControl
    {
        DataAccess db = new DataAccess();

        public UC_login()
        {
            InitializeComponent();
            this.Load += UC_login_Load; // Subscribe to the Load event
        }

        private void UC_login_Load(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            loginControl lc = this.ParentForm as loginControl;

            string username = guna2TextBox1.Text;
            string password = guna2TextBox2.Text;

            try
            {
                var user = db.spLogin(username);
                var perm = db.GetUsersPerm(username);

                if (user.Count == 1 && VerifySHA1Hash(password, user[0].palavrapasse))
                {
                    Admin adminhome = new Admin();
                    adminhome.panel2.Controls.Clear();

                    if (perm != null && perm.Count > 0 && perm[0].permissao == 0)
                    {
                        UC.UC_menuuser uC_Maismenu = new UC.UC_menuuser();
                        adminhome.panel2.Controls.Add(uC_Maismenu);
                    }
                    else
                    {

                        UC.UC_menuadmin uC_menuadmin = new UC.UC_menuadmin();
                        adminhome.panel2.Controls.Add(uC_menuadmin);

                    }

                    lc.Hide();
                    adminhome.Show();
                }
                else
                {
                    MessageBox.Show("Password incorreta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool VerifySHA1Hash(string input, string hash)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hashedInput = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hash) == 0;
            }
        }

        public void guna2Button3_Click(object sender, EventArgs e)
        {
            UC.UC_signup sp = new UC.UC_signup();
            loginControl lc = this.ParentForm as loginControl;
            lc.panel1.Controls.Clear();
            lc.panel1.Controls.Add(sp);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.UseSystemPasswordChar)
            {
                guna2TextBox2.UseSystemPasswordChar = false;
                pictureBox1.Image = System.Drawing.Image.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GestaoFormacao", "GestaoFormacao", "ico", "eye-slash-solid.png"));
            }
            else
            {
                guna2TextBox2.UseSystemPasswordChar = true;
                pictureBox1.Image = System.Drawing.Image.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "source", "repos", "GestaoFormacao", "GestaoFormacao", "ico", "eye-solid.png"));
            }
        }
    }
}

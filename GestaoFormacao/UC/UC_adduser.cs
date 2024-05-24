using System;
using System.Text;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_adduser : UserControl
    {
        DataAccess db = new DataAccess();
        public UC_adduser()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var password = guna2TextBox2.Text;
            password = CalculateSHA1Hash(password);
            int perm;
            if (guna2ComboBox1.Text == "Admin")
            {
                perm = 1;
            }
            else
            {
                perm = 0;
            }
            try
            {
                db.InsertUser(guna2TextBox1.Text, guna2TextBox4.Text, password, perm);
                Return();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CalculateSHA1Hash(string input)
        {
            using (System.Security.Cryptography.SHA1Managed sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
        public void Return()
        {
            UC.UC_utilizadores uC_Utilizadores = new UC.UC_utilizadores();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_Utilizadores);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Return();
        }
    }
}

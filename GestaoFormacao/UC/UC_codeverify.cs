using System;
using System.Text;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_codeverify : UserControl
    {
        public UC_codeverify()
        {
            InitializeComponent();
        }
        public string CalculateSHA1Hash(string input)
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
        public void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == UC_signup.code)
            {
                UC.UC_login uC_login = new UC.UC_login();
                DataAccess db = new DataAccess();
                var password = CalculateSHA1Hash(UC_signup.guna2);
                db.InsertUser(UC_signup.guna1, UC_signup.guna4, password, 0);
                loginControl lc = this.ParentForm as loginControl;
                lc.panel1.Controls.Clear();
                lc.panel1.Controls.Add(uC_login);

            }
            else
            {
                MessageBox.Show("Código incorreto");
            }
        }

        public void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
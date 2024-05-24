using GestaoFormacao.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_modulos : UserControl
    {
        DataAccess dataAccess = new DataAccess();
        List<Models.tipo_formacao> tf = new List<Models.tipo_formacao>();
        List<Models.tipo_modulo> tm = new List<Models.tipo_modulo>();
        List<Models.Avaliacao> a = new List<Models.Avaliacao>();
        public UC_modulos()
        {
            InitializeComponent();
        }

        private void UC_modulos_Load(object sender, EventArgs e)
        {
            tf = dataAccess.GetTipoFormacao();
            tm = dataAccess.GetTipoModulo();
            a = dataAccess.GetAvaliacao();          

            guna2ComboBox1.DataSource = tf;
            guna2ComboBox1.DisplayMember = "nome";
            guna2ComboBox1.ValueMember = "id";

            guna2ComboBox2.DataSource = tm;
            guna2ComboBox2.DisplayMember = "nome";
            guna2ComboBox2.ValueMember = "id";

            guna2ComboBox3.DataSource = a;
            guna2ComboBox3.DisplayMember = "tipo_avaliacao";
            guna2ComboBox3.ValueMember = "id";

            label8.Text = guna2TrackBar1.Value.ToString();
            guna2DateTimePicker1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UC.UC_menumodulos menumodulos = new UC.UC_menumodulos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(menumodulos);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string nome = guna2TextBox1.Text;
            string descricao = richTextBox1.Text;
            DateTime? data_max = null;
            int horas = guna2TrackBar1.Value;
            int tipo_formacao = (int)guna2ComboBox1.SelectedValue;
            int tipo_modulo = (int)guna2ComboBox2.SelectedValue;
            string url = guna2TextBox2.Text;
            int avaliacao = (int)guna2ComboBox3.SelectedValue;

            if (checkBox1.Checked)
            {
                data_max = guna2DateTimePicker1.Value;
            }

            dataAccess.InsertModule(nome, descricao, horas, data_max, tipo_formacao, tipo_modulo, url, avaliacao);

            MessageBox.Show("O módulo foi adicionado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            richTextBox1.Clear();
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2TrackBar1.Value = 0;
        }

        private void guna2TrackBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            label8.Text = guna2TrackBar1.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                guna2DateTimePicker1.Enabled = true;
            }
            else
            {
                guna2DateTimePicker1.Enabled = false;
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_menumodulos uC_menumodulos = new UC_menumodulos();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_menumodulos);
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

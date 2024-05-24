using GestaoFormacao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoFormacao.UC
{
    public partial class UC_percursos : UserControl
    {
        DataAccess db = new DataAccess();
        List<Models.Modulos> modules = new List<Models.Modulos>();
        List<Models.Level> levels = new List<Models.Level>();

        public UC_percursos()
        {
            InitializeComponent();
        }
        private void UC_percursos_Load(object sender, EventArgs e)
        {
            modules = db.GetModules();
            levels = db.GetLevels();
            guna2DataGridView3.DataSource = modules;
            guna2DataGridView3.Columns["id"].Visible = false;
            guna2DataGridView3.Columns["horas"].Visible = false;
            guna2DataGridView3.Columns["data_max"].Visible = false;
            guna2DataGridView3.Columns["tipo_formacao"].Visible = false;
            guna2DataGridView3.Columns["tipo_modulo"].Visible = false;
            guna2DataGridView3.Columns["url"].Visible = false;
            guna2DataGridView3.Columns["tipo_avaliacao"].Visible = false;
            guna2DataGridView3.Columns["ativo"].Visible = false;
            guna2DataGridView2.DataSource = levels;
            guna2DataGridView2.Columns["Id"].Visible = false;

            foreach (DataGridViewColumn column in guna2DataGridView3.Columns)
            {
                guna2DataGridView1.Columns.Add(column.Clone() as DataGridViewColumn);
            }
            UpdateBinding();
        }
        private void UpdateBinding()
        {
            guna2DataGridView3.Refresh();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UC.UC_percursomenu uC_percursomenu = new UC_percursomenu();
            Admin admin = this.ParentForm as Admin;
            admin.panel3.Controls.Clear();
            admin.panel3.Controls.Add(uC_percursomenu);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            modules = db.SearchModule(guna2TextBox2.Text);
            if (string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                modules = db.GetModules();
                guna2DataGridView3.DataSource = modules;
            }
            else
            {
                guna2DataGridView3.DataSource = modules;
                UpdateBinding();
            }
        }
        List<Models.Modulos> usedModules = new List<Models.Modulos>();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView3.SelectedRows[0];
                Models.Modulos selectedModule = selectedRow.DataBoundItem as Models.Modulos;

                if (!usedModules.Contains(selectedModule))
                {
                    DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                    for (int i = 0; i < selectedRow.Cells.Count; i++)
                    {
                        newRow.Cells[i].Value = selectedRow.Cells[i].Value;
                    }
                    guna2DataGridView1.Rows.Add(newRow);
                    usedModules.Add(selectedModule);
                    UpdateBinding();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;
                if (selectedRowIndex > 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                    guna2DataGridView1.Rows.RemoveAt(selectedRowIndex);
                    guna2DataGridView1.Rows.Insert(selectedRowIndex - 1, selectedRow);
                    guna2DataGridView1.ClearSelection();
                    guna2DataGridView1.Rows[selectedRowIndex - 1].Selected = true;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;
                if (selectedRowIndex < guna2DataGridView1.Rows.Count - 2)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                    guna2DataGridView1.Rows.Remove(selectedRow);
                    guna2DataGridView1.Rows.Insert(selectedRowIndex + 1, selectedRow);
                    guna2DataGridView1.ClearSelection();
                    guna2DataGridView1.Rows[selectedRowIndex + 1].Selected = true;
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                int selectedIndex = guna2DataGridView1.Rows.IndexOf(selectedRow);

                if (selectedIndex != -1)
                {
                    guna2DataGridView1.Rows.Remove(selectedRow);
                    if (selectedIndex < usedModules.Count)
                    {
                        usedModules.RemoveAt(selectedIndex);
                        UpdateBinding();
                    }
                }
            }
        }

        private void guna2DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            List<object> jsonDataList = new List<object>();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["Id"].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    int index = row.Index;
                    var data = new
                    {
                        Id = id,
                        Index = index+1
                    };
                    jsonDataList.Add(data);
                }
            }
            string modulesjson = JsonConvert.SerializeObject(jsonDataList);
            int selectedLevelIndex = guna2DataGridView2.SelectedRows[0].Index;
            db.InsertPercurso(guna2TextBox1.Text, richTextBox1.Text, selectedLevelIndex, modulesjson);
            MessageBox.Show("Percurso adicionado com sucesso!");
        }
    }
}

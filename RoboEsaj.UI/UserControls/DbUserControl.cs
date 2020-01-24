using System;
using System.Windows.Forms;
using RoboEsaj.Database.Models;
using RoboEsaj.Domain.Utilities;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Collections.Generic;

namespace RoboEsaj.UI.UserControls
{
    public partial class DbUserControl : UserControl
    {
        private string _connectionString => ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        private List<DecisaoModel> decisoes = new List<DecisaoModel>();

        public DbUserControl()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                decisaoModelBindingSource.DataSource = SqliteDataAccess.SearchDecisao(txtPesquisarDb.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhum resultado encontrado!", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void LoadDatabase()
        {
            try
            {
                decisaoModelBindingSource.DataSource = SqliteDataAccess.LoadDecisao();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível carregar dados!", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja apagar todos os dados do banco?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    SqliteDataAccess.ClearDatabase();
                    LoadDatabase();
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível remover os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnDgvExport_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx = new CreateXlsx();

                xlsx.OpenExcel(dgvEsaj);

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível abrir o arquivo.\nTalvez o Excel, ou equivalente, não esteja instalado.", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        private void Save_Excel(object sender, EventArgs e)
        {
            try
            {
                var fileName = Interaction.InputBox("Digite o nome do arquivo:", "Salvar", "Nome do arquivo", -1, -1);

                if (fileName.Length > 0)
                {
                    var xlsx = new CreateXlsx();

                    xlsx.SaveXlsx(dgvEsaj, fileName);
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void txtPesquisarDb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnPesquisarDb.Focus();
                btnPesquisarDb.PerformClick();
            }
        }
    }
}

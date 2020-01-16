using System;
using System.Windows.Forms;
using RoboEsaj.Domain.Utilities;
using RoboEsaj.Database.Models;

namespace RoboEsaj.UI.Forms
{
    public partial class FrmEsaj : Form
    {
        public ClasseDeNavegacao EsajDois { get; private set; }
        public string TextoPesquisa { get; private set; }

        public FrmEsaj()
        {
            InitializeComponent();
            robotUserControl1.BringToFront();
            dbUserControl1.Hide();
        }

        private void CloseApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPesquisaJur_Click(object sender, EventArgs e)
        {
            dbUserControl1.Hide();
            robotUserControl1.Show();
            robotUserControl1.BringToFront();
        }

        private void btnDatabaseCons_Click(object sender, EventArgs e)
        {
            robotUserControl1.Hide();
            dbUserControl1.LoadDatabase();
            dbUserControl1.Show();
            dbUserControl1.BringToFront();
        }
    }
}

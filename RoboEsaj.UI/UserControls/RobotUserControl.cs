using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboEsaj.Domain.Utilities;

namespace RoboEsaj.UI.UserControls
{
    public partial class RobotUserControl : UserControl
    {
        public ClasseDeNavegacao EsajDois { get; private set; }
        public IList<string> DadosPesquisa { get; private set; }
        public string TextoPesquisa { get; private set; }
        public string Assunto { get; private set; }
        public string NomeMagistrado { get; private set; }
        public string Vara { get; private set; }

        public RobotUserControl()
        {
            InitializeComponent();
        }

        private void btnE_Click(object sender, EventArgs e) => txbPesquisa.Text += " E ";

        private void btnOu_Click(object sender, EventArgs e) => txbPesquisa.Text += " OU ";

        private void btnNao_Click(object sender, EventArgs e) => txbPesquisa.Text += " NÃO ";

        private void btnInterroga_Click(object sender, EventArgs e) => txbPesquisa.Text += "?";

        private void btnAster_Click(object sender, EventArgs e) => txbPesquisa.Text += "*";

        private void btnAspas_Click(object sender, EventArgs e)
        {
            var texto = txbPesquisa.Text;
            texto = "\"" + texto + "\"";
            txbPesquisa.Clear();
            txbPesquisa.Text = texto;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Criar uma lista de string para receber os argumentos e passar para o método scrape
            DadosPesquisa = new List<string>();

            DadosPesquisa.Add(txbPesquisa.Text); //Pesquisa Livre
            DadosPesquisa.Add(cBAssunto.GetItemText(cBAssunto.SelectedItem)); //Assunto
            DadosPesquisa.Add(txtMagistrado.Text); //Magistrado
            DadosPesquisa.Add(txtDataInicial.Text); // Data Inicial
            DadosPesquisa.Add(txtDataFinal.Text); // Data Final
            DadosPesquisa.Add(cbVara.GetItemText(cbVara.SelectedItem)); // Vara

            //TextoPesquisa = txbPesquisa.Text;
            //Assunto = cBAssunto.GetItemText(cBAssunto.SelectedItem);
            //NomeMagistrado = txtMagistrado.Text;
            //Vara = cbVara.GetItemText(cbVara.SelectedItem);

            bool allSame = DadosPesquisa.All(item => item == "");

            if (allSame)
            {
                MessageBox.Show("É preciso preencher ao menos um campo", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                EsajDois = new ClasseDeNavegacao();
                EsajDois.Scrape(DadosPesquisa);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

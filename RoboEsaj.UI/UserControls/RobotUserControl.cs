using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OpenQA.Selenium;
using RoboEsaj.Domain.Utilities;

namespace RoboEsaj.UI.UserControls
{
    public partial class RobotUserControl : UserControl
    {
        public ScrapClass EsajDois { get; private set; }
        public IList<string> DadosPesquisa { get; private set; }
        public bool LinkCheck { get; set; }

        public RobotUserControl()
        {
            InitializeComponent();
            txbPesquisa.Focus();
            txbPesquisa.Select();
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
            DadosPesquisa = new List<string>();

            DadosPesquisa.Add(txbPesquisa.Text); //Pesquisa Livre
            DadosPesquisa.Add(txtAssunto.Text); //Assunto
            DadosPesquisa.Add(txtMagistrado.Text); //Magistrado
            DadosPesquisa.Add(txtDataInicial.Text); // Data Inicial
            DadosPesquisa.Add(txtDataFinal.Text); // Data Final
            DadosPesquisa.Add(cbVara.GetItemText(cbVara.SelectedItem)); // Vara

            bool allSame = DadosPesquisa.All(item => item == "");

            if (allSame)
            {
                MessageBox.Show("É preciso preencher ao menos um campo", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LinkCheck = cbLink.Checked;

            try
            {
                EsajDois = new ScrapClass();
                EsajDois.Scrape(DadosPesquisa, LinkCheck);
            }
            catch (NoSuchElementException exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ElementNotVisibleException exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (ElementNotSelectableException exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (TimeoutException exception)
            {
                MessageBox.Show(exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(Exception exception)
            {
            }
        }

        private void txbPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }

        private void txtAssunto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }

        private void txtMagistrado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }

        private void txtDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }

        private void txtDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }

        private void cbVara_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnConsultar.Focus();
                btnConsultar.PerformClick();
            }
        }
    }
}

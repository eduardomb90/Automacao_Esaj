using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RoboEsaj.Domain.Helpers;

namespace RoboEsaj.Domain.Utilities
{
    public class ClasseDeNavegacao : IClasseDeNavegacao
    {
        private string _connectionString => ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;
        private IClock _clock;


        private int tableIndex = 1;

        private string _url = "https://esaj.tjsp.jus.br/cjpg/";
        private By InputPesquisaId = By.Id("iddadosConsulta.pesquisaLivre");
        private By InputMagistradoId = By.Id("nmAgente");
        private By ButtonSubmitPesquisa = By.Id("pbSubmit");
        private By MessageAtencao = By.CssSelector("div[id='spwTabelaMensagem']");
        private By MessageNoResult = By.CssSelector("div[class='aviso espacamentoCimaBaixo centralizado fonteNegrito']");
        private By ButtonProcurarAssunto = By.Id("botaoProcurar_assunto");
        private By ButtonProcurarVara = By.Id("botaoProcurar_varas");
        private By InputVaraFilter = By.Id("varas_treeSelectFilter");
        private By ButtonVaraFilter = By.Id("filtroButton");
        private By Assuntos = By.CssSelector("span[id*='assunto_tree']");
        private By InputDataInicialId = By.Id("iddadosConsulta.dtInicio");
        private By InputDataFinalId = By.Id("iddadosConsulta.dtFim");
        private By Varas = By.CssSelector("span[id*='varas_tree']");
        private By ButtonSelectAssunto = By.CssSelector("div#divContainerTree_assunto input.spwBotaoDefaultGrid[value='Selecionar']");
        private By ButtonSelectVara = By.CssSelector("div#divContainerTree_varas input.spwBotaoDefaultGrid[value='Selecionar']");
        private By NextPage = By.CssSelector("a.esajLinkLogin[title='Próxima página']");
        private By ShowHidden = By.CssSelector("img.mostrarOcultarConteudo[src*='icoMais']");
        private By Tables = By.ClassName("fundocinza1");
        private By TableRows = By.ClassName("fonte");

        private IWebElement InputPesquisa { get; set; }
        private IWebElement InputMagistrado { get; set; }
        private IWebElement AssuntoOpenButton { get; set; }
        private IWebElement AssuntoCloseButton { get; set; }
        private IWebElement InputDataInicial { get; set; }
        private IWebElement InputDataFinal { get; set; }
        private IWebElement VaraOpenButton { get; set; }
        private IWebElement VaraFilter { get; set; }
        private IWebElement VaraFilterButton { get; set; }
        private IWebElement VaraCloseButton { get; set; }

        private IEnumerable<IWebElement> opcoes;

        public ClasseDeNavegacao()
        {
            _driver = DriverDoChrome.GetChrome();
            _clock = _clock = new SystemClock();
            _wait = new WebDriverWait(_clock, _driver, TimeSpan.FromMinutes(4), TimeSpan.FromSeconds(3));
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public void Scrape(IList<string> dadosPesquisa)
        {
            try
            {
                GoToSite();
                GetFormElements();
                FillPesquisa(dadosPesquisa);
                SubmitPesquisa();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                _driver.Quit();
                return;
            }

            bool present;

            do
            {
                bool msgAtencao = IsElementPresent(MessageAtencao);
                if (msgAtencao)
                {
                    var msg = _driver.FindElement(MessageAtencao).Text;
                    _driver.Quit();
                    MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                bool result = IsElementPresent(MessageNoResult);
                if (result)
                {
                    var msg = _driver.FindElement(MessageNoResult).Text;
                    _driver.Quit();
                    MessageBox.Show(msg, "Sem resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                try
                {
                    GetTableElements();
                }
                catch (Exception)
                {
                    return;
                }
                
                present = IsElementPresent(NextPage);
                if (present)
                {
                    try
                    {
                        ProximaPagina();
                    }
                    catch (Exception)
                    {
                        return;
                    }   
                    
                    try
                    {
                        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Tables)); // Visible
                        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(ShowHidden)); //Esperar o símbolo de +
                        
                        Thread.Sleep(2000);
                    }
                    catch (Exception)
                    {
                        _driver.Quit();
                        MessageBox.Show("Conteúdo demorou muito para carregar.", "Tempo esgotado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            } while (present);

            _driver.Quit();
            MessageBox.Show("Coleta de dados concluída!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void GoToSite()
        {
            try
            {
                _driver.Navigate().GoToUrl(_url); 
            }
            catch (Exception)
            {
                _driver.Quit();
                MessageBox.Show("Não foi possível acessar o site!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void GetFormElements()
        {
            try
            {
                InputPesquisa = _driver.FindElement(InputPesquisaId);
                InputMagistrado = _driver.FindElement(InputMagistradoId);
                AssuntoOpenButton = _driver.FindElement(ButtonProcurarAssunto);
                InputDataInicial = _driver.FindElement(InputDataInicialId);
                InputDataFinal = _driver.FindElement(InputDataFinalId);
                VaraOpenButton = _driver.FindElement(ButtonProcurarVara);
            }
            catch (NoSuchElementException)
            {
                _driver.Quit();
                MessageBox.Show("Elementos de pesquisa não encontrados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void OpenAssunto() => AssuntoOpenButton.Click();

        private void CloseAssunto() => AssuntoCloseButton.Click();

        private void SelectAssunto(string assunto)
        {
            if (assunto != "")
            {
                OpenAssunto();

                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Assuntos));
                opcoes = _driver.FindElements(Assuntos);

                opcoes
                   .Where(o => o.Text.Contains(assunto))
                   .FirstOrDefault().Click();

                AssuntoCloseButton = _driver.FindElement(ButtonSelectAssunto);

                CloseAssunto();
            }
        }

        private void OpenVara() => VaraOpenButton.Click();

        private void CloseVara() => VaraCloseButton.Click();

        private void ForoFilter(string foro)
        {
            VaraFilter = _driver.FindElement(InputVaraFilter);
            VaraFilterButton = _driver.FindElement(ButtonVaraFilter);
            VaraFilter.SendKeys(foro);
            VaraFilterButton.Click();
        }
        
        private void SelectVara(string vara)
        {
            if (vara != "")
            {
                OpenVara();

                if (vara == "SÃO PAULO")
                {
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(InputVaraFilter));

                    ForoFilter(vara);

                    Thread.Sleep(2000);
                
                    opcoes = _driver.FindElements(Varas);
                    
                    opcoes                        
                        .ToList()
                        .ForEach(o =>
                        {
                            if (o.Text != "Foro Central Criminal Barra Funda" &&
                                o.Text != "Foro Central Juizados Especiais Cíveis" &&
                                o.Text.Contains("riminal") || o.Text.Contains("amília") || 
                                o.Text.Contains("uizado") || o.Text.Contains("alência") ||
                                o.Text.Contains("nfância"))
                            {
                                o.Click();
                            }
                        });
                }
                else
                {
                    _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Varas));
                    opcoes = _driver.FindElements(Varas);

                    opcoes
                       .Where(o => o.Text.Contains(vara))
                       .FirstOrDefault()
                       .Click();
                }

                VaraCloseButton = _driver.FindElement(ButtonSelectVara);

                CloseVara();
            }
        }

        private void FillPesquisa(IList<string> dadosPesquisa)
        {
            InputPesquisa.SendKeys(dadosPesquisa[0]);
            SelectAssunto(dadosPesquisa[1]);
            InputMagistrado.SendKeys(dadosPesquisa[2]);
            InputDataInicial.SendKeys(dadosPesquisa[3]);
            InputDataFinal.SendKeys(dadosPesquisa[4]);
            SelectVara(dadosPesquisa[5]);
        }

        private void SubmitPesquisa()
        {
            try
            {
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ButtonSubmitPesquisa)).Click();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível submeter a pesquisa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void GetTableElements()
        {
            try
            {
                _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Tables));
            }
            catch (Exception)
            {
                _driver.Quit();
                MessageBox.Show("Erro ao tentar extrair as decisões.\nDecisões demoraram muito para carregar.", "Tempo esgotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
            var tables = _driver.FindElements(Tables);

            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    foreach (var table in tables)
                    {
                        var dbFill = new PreencheBancoDeDados();

                        table.FindElement(ShowHidden).Click();

                        var textIndex = $"{tableIndex} -";
                        var rows = table.FindElements(TableRows);

                        if (rows[0].Text == textIndex)
                        {
                            dbFill.AddToDb(rows, conn);
                            tableIndex++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao tentar salvar decisão no banco de dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ProximaPagina()
        {
            Thread.Sleep(1000);
            try
            {
                _driver.FindElement(NextPage).Click(); 
            }
            catch (Exception)
            {
                _driver.Quit();
                MessageBox.Show("Não foi possível passar para próxima página.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}

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
using RoboEsaj.Database.Models;
using RoboEsaj.Domain.Helpers;

namespace RoboEsaj.Domain.Utilities
{
    public class ScrapClass : IScrapClass
    {
        private string _connectionString => ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private readonly IWebDriver _driver;
        private WebDriverWait Wait { get; set; }
        private DecisaoModel Decisao { get; set; }
        private FillDataClass DbFill { get; set; }
        private ScrapingHelper Scraping { get; set; }
        private int _tableIndex = 1;
        private IEnumerable<IWebElement> Options { get; set; }

        private string _url = "https://esaj.tjsp.jus.br/cjpg/";
        private By InputPesquisaText = By.Id("iddadosConsulta.pesquisaLivre");
        private By ButtonProcurarAssunto = By.Id("botaoProcurar_assunto");
        private By InputAssuntoFilter = By.Id("assunto_treeSelectFilter");
        private By ButtonAssuntoFilter = By.CssSelector("div#assunto_treeSelectContainer input#filtroButton[value='Procurar']");
        private By Assuntos = By.CssSelector("span[id*='assunto_tree']");
        private By ButtonSelectAssunto = By.CssSelector("div#divContainerTree_assunto input.spwBotaoDefaultGrid[value='Selecionar']");
        private By InputMagistradoId = By.Id("nmAgente");
        private By InputDataInicialId = By.Id("iddadosConsulta.dtInicio");
        private By InputDataFinalId = By.Id("iddadosConsulta.dtFim");
        private By InputVaraText = By.Id("varas_selectionText");
        private By ButtonProcurarVara = By.Id("botaoProcurar_varas");
        private By InputVaraFilter = By.Id("varas_treeSelectFilter");
        private By ButtonVaraFilter = By.CssSelector("div#varas_treeSelectContainer input#filtroButton[value='Procurar']");
        private By Varas = By.CssSelector("span[id*='varas_tree']");
        private By SubVarasSp = By.CssSelector("span[id*='varas_tree'][searchvalue*='sao paulo sao paulo']");
        private By ButtonSelectVara = By.CssSelector("div#divContainerTree_varas input.spwBotaoDefaultGrid[value='Selecionar']");
        private By ButtonSubmitPesquisa = By.Id("pbSubmit");
        private By MessageAtencao = By.CssSelector("div[id='spwTabelaMensagem']");
        private By MessageNoResult = By.CssSelector("div[class='aviso espacamentoCimaBaixo centralizado fonteNegrito']");
        private By NextPage = By.CssSelector("a.esajLinkLogin[title='Próxima página']");
        private By ShowNewWindow = By.CssSelector("img[title='Visualizar Inteiro Teor']");
        private By ShowHidden = By.CssSelector("img.mostrarOcultarConteudo[src*='icoMais']");
        private By Tables = By.ClassName("fundocinza1");
        private By TableRows = By.ClassName("fonte");

        public ScrapClass()
        {
            _driver = DriverDoChrome.GetChrome();
            Wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(1));
            Decisao = new DecisaoModel();
            DbFill = new FillDataClass(Decisao);
            Scraping = new ScrapingHelper(_driver, Wait, Decisao);
        }

        public void Scrape(IList<string> dadosPesquisa, bool linkCheck)
        {
            try
            {
                Scraping.GoToSite(_url);
                SubmitPesquisa(dadosPesquisa);

                Scraping.IsMessagePresent(MessageAtencao);
                Scraping.IsMessagePresent(MessageNoResult);

                bool present;
                do
                {
                    GetTableElements(linkCheck, Tables, ShowNewWindow, ShowHidden);
            
                    present = Scraping.IsElementPresent(NextPage);
                    if (present)
                    {
                        Scraping.ProximaPagina(NextPage);
                        Scraping.IsLoaded(ShowHidden);
                    }

                } while (present);

                _driver.Quit();
                MessageBox.Show("Coleta de dados concluída!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OpenButton(By openButton) => _driver.FindElement(openButton).Click();

        private void CloseButton(By closeButton) => _driver.FindElement(closeButton).Click();

        private void Filter(By inputFilter, By buttonFilter, string assunto)
        {
            _driver.FindElement(inputFilter).SendKeys(assunto);
            _driver.FindElement(buttonFilter).Click();
        }

        private void WaitAndFilter(By element, string textFilter, By button)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            Filter(element, button, textFilter);
        }

        private void SelectAssunto(string assunto)
        {
            if (assunto != "")
            {
                OpenButton(ButtonProcurarAssunto);

                try
                {
                   WaitAndFilter(InputAssuntoFilter, assunto, ButtonAssuntoFilter);
                    Thread.Sleep(2000);

                    Options = _driver.FindElements(Assuntos);
                    Options
                        .Where(o => o.Text.IndexOf(assunto, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList()
                        .ForEach(o =>
                        {
                            o.Click();
                        });
                }
                catch (Exception)
                {
                    throw new Exception("Falha ao tentar selecionar assunto!");
                }

                CloseButton(ButtonSelectAssunto);
            }
        }
        
        private void SelectVara(string vara)
        {
            if (vara != "")
            {
                try
                {
                    OpenButton(ButtonProcurarVara);

                    if (vara == "SÃO PAULO")
                    {
                        WaitAndFilter(InputVaraFilter, vara, ButtonVaraFilter);
                        Thread.Sleep(1000);

                        SelectVarasAndSubVaras(vara, Varas, SubVarasSp);
                    }
                    else
                    {
                        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Varas));
                        SelectFirstOccurrence(vara, Varas);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Falha ao tentar selecionar varas!");
                }
                CloseButton(ButtonSelectVara);
            }
        }

        private IWebElement SelectFirstOccurrence(string filter , By selectElement)
        {
            Options = _driver.FindElements(selectElement);
            var option = Options
                            .Where(o => o.Text.Contains(filter))
                            .FirstOrDefault();
            option.Click();
            return option;
        }

        private void SelectVarasAndSubVaras(string filter, By varaElement, By subVaraElement)
        {
            var option = SelectFirstOccurrence(filter, varaElement);

            var SubOpcoes = _driver.FindElements(subVaraElement);

            SubOpcoes
                    .ToList()
                    .ForEach(o =>
                    {
                        if ((o.Text != "Foro Central Criminal Barra Funda" &&
                            o.Text != "Foro Central Juizados Especiais Cíveis")
                            &&
                            (o.Text.Contains("riminal") || o.Text.Contains("amília") ||
                            o.Text.Contains("uizado") || o.Text.Contains("alência") ||
                            o.Text.Contains("nfância")))
                        {
                            o.Click();
                        }
                    });
        }

        private void FillPesquisa(IList<string> dadosPesquisa)
        {
            try
            {
                if (dadosPesquisa[0] != "")
                {
                    _driver.FindElement(InputPesquisaText).SendKeys(dadosPesquisa[0]);
                }
                if (dadosPesquisa[1] != "")
                {
                    SelectAssunto(dadosPesquisa[1]);
                }
                if (dadosPesquisa[2] != "")
                {
                    _driver.FindElement(InputMagistradoId).SendKeys(dadosPesquisa[2]);
                }
                if (dadosPesquisa[3] != "")
                {
                    _driver.FindElement(InputDataInicialId).SendKeys(dadosPesquisa[3]);
                }
                if (dadosPesquisa[4] != "")
                {
                    _driver.FindElement(InputDataFinalId).SendKeys(dadosPesquisa[4]);
                }
                if (dadosPesquisa[5] != "")
                {
                    _driver.FindElement(InputVaraText).Click();
                    SelectVara(dadosPesquisa[5]);
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível preencher a pesquisa!");
            }
            
        }

        private void SubmitPesquisa(IList<string> dadosPesquisa)
        {
            FillPesquisa(dadosPesquisa);

            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ButtonSubmitPesquisa)).Click();
                Thread.Sleep(1000);
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível submeter a pesquisa!");
            }
        }

        private void GetTableElements(bool linkCheck, By element, By windowElement, By plusElement)
        {
            Scraping.IsLoaded(element);
            var tables = Scraping.FindElements(element);

            try
            {
                using (IDbConnection conn = new SQLiteConnection(_connectionString))
                {
                    foreach (var table in tables)
                    {
                        Scraping.GetLink(linkCheck,  windowElement, table);

                        Scraping.ClickLoop(table, plusElement);
                        
                        var textIndex = $"{_tableIndex} -";
                        var rows = table.FindElements(TableRows);

                        if (rows[0].Text == textIndex)
                        {
                            DbFill.AddToDb(rows, conn);
                            _tableIndex++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private void ProximaPagina() //Colocar um loop aqui
        //{
        //    //Thread.Sleep(1000);
        //    try
        //    {
        //        _driver.FindElement(NextPage).Click(); 
        //    }
        //    catch (Exception)
        //    {
        //        _driver.Quit();
        //        throw new Exception("Não foi possível passar para próxima página.");
        //    }
        //}

        //private bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        _driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        //private void IsLoaded(By by)
        //{
        //    bool present;
        //    do
        //    {
        //        present = ScrapingAction.IsElementPresent(by, _driver);
        //    } while (!present);

        //    try
        //    {
        //        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by)); //ElementIsVisible
        //    }
        //    catch (Exception)
        //    {
        //        _driver.Quit();
        //        throw new Exception("Site demorou muito para carregar.");
        //    }
        //}

        //private void IsLoaded(By firstBy, By secondBy)
        //{
        //    bool present;
        //    do
        //    {
        //        present = ScrapingAction.IsElementPresent(firstBy, _driver);
        //    } while (!present);

        //    try
        //    {
        //        bool waiting;
        //        do
        //        {
        //            waiting = ScrapingAction.LoopWait(firstBy, secondBy, _driver);
        //        } while (!waiting);
        //    }
        //    catch (Exception)
        //    {
        //        //_driver.Quit();
        //        throw new Exception("Site demorou muito para carregar.");
        //    }
        //}

        //private void IsMessagePresent(By message)
        //{
        //    bool present = ScrapingAction.IsElementPresent(message, _driver);
        //    if (present)
        //    {
        //        var msg = _driver.FindElement(message).Text;
        //        _driver.Quit();
        //        MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //}



        //private bool ClickOnPlus(IWebElement table)
        //{
        //    try
        //    {
        //        table.FindElement(ShowHidden).Click();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //private bool LoopWait(By firstBy, By secondBy)
        //{
        //    var wait = new WebDriverWait(new SystemClock(), _driver, TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(3));
        //    try
        //    {
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(firstBy)); //ElementIsVisible
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(secondBy)); //Esperar o símbolo de +
        //        Thread.Sleep(1000);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //private bool ClickNewWindow(IWebElement table)
        //{
        //    try
        //    {
        //        table.FindElement(ShowNewWindow).Click();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //private void GetLink(bool linkCheck)
        //{
        //    if (linkCheck)
        //    {
        //        var tables = _driver.FindElements(Tables);

        //        foreach (var table in tables)
        //        {
        //            bool clicked;
        //            do
        //            {
        //                clicked = ScrapingAction.ClickNewWindow(table, ShowNewWindow);
        //            } while (!clicked);

        //            ScrapingAction.SwitchToTab(_driver);
        //        }
        //    }
        //}

        //public void SwitchToTab()
        //{
        //    var originalPage = _driver.WindowHandles.First();
        //    var popup = _driver.WindowHandles.Last(); // handler for the new tab
        //    //Assert.True(!string.IsNullOrEmpty(popup)); // tab was opened
        //    //var url = _driver.Url;
        //    var url = _driver.SwitchTo().Window(popup).Url;
        //    //_driver.SwitchTo().Window(popup); // fecha a nova aba 
        //    _driver.SwitchTo().Window(popup).Close(); // fecha a nova aba 
        //    _driver.SwitchTo().Window(originalPage); // foca na aba original
        //}
    }
}

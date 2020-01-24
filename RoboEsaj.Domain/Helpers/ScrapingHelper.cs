using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RoboEsaj.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace RoboEsaj.Domain.Helpers
{
    public class ScrapingHelper
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        private DecisaoModel Decisao { get; set; }


        public ScrapingHelper(IWebDriver driver, WebDriverWait wait, DecisaoModel decisao)
        {
            Driver = driver;
            Wait = wait;
            Decisao = decisao;
        }


        public void GoToSite(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                Driver.Quit();
                throw new Exception("Não foi possível acessar o site!");
            }
        }

        public void IsMessagePresent(By message)
        {
            bool present = IsElementPresent(message);
            if (present)
            {
                var msg = Driver.FindElement(message).Text;
                Driver.Quit();
                MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void IsLoaded(By by)
        {
            bool present;
            do
            {
                present = IsElementPresent(by);
            } while (!present);

            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by)); //ElementIsVisible
            }
            catch (Exception)
            {
                Driver.Quit();
                throw new Exception("Site demorou muito para carregar as decisões!");
            }
        }

        public void IsPageLoaded(By firstBy, By secondBy)
        {
            bool present;
            do
            {
                present = IsElementPresent(firstBy);
            } while (!present);

            try
            {
                bool waiting;
                do
                {
                    waiting = LoopWaitTables(firstBy, secondBy);
                } while (!waiting);
            }
            catch (Exception)
            {
                Driver.Quit();
                throw new Exception("Site demorou muito para carregar uma nova página!");
            }
        }
        
        public bool ClickTableNewWindow(IWebElement table, By element)
        {
            try
            {
                table.FindElement(element).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SwitchTabGetLink(DecisaoModel decisao)
        {
            var originalPage = Driver.WindowHandles.First();
            var popup = Driver.WindowHandles.Last(); // handler for the new tab
            Assert.True(!string.IsNullOrEmpty(popup)); // tab was opened
            decisao.Link = Driver.SwitchTo().Window(popup).Url;
            Driver.SwitchTo().Window(popup).Close(); // fecha a nova aba 
            Driver.SwitchTo().Window(originalPage); // foca na aba original
        }

        public void GetLink(bool linkCheck, By linkElement, IWebElement tableElement)
        {
            if (linkCheck)
            {
                bool clicked;
                do
                {
                    clicked = ClickTableNewWindow(tableElement, linkElement);
                } while (!clicked);

                SwitchTabGetLink(Decisao);
            }
        }

        public bool ClickOnTablePlus(IWebElement table, By element)
        {
            try
            {
                table.FindElement(element).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LoopWaitTables(By firstBy, By secondBy)
        {
            try
            {
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(firstBy)); //ElementIsVisible
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(secondBy)); //Esperar o símbolo de +
                Thread.Sleep(1000);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ProximaPagina(By nextPageElement) //Colocar um loop aqui
        {
            //Thread.Sleep(1000);
            try
            {
                Driver.FindElement(nextPageElement).Click();
            }
            catch (Exception)
            {
                Driver.Quit();
                throw new Exception("Não foi possível passar para próxima página.");
            }
        }
    }
}

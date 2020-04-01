using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RoboEsaj.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoboEsaj.Domain.Helpers
{
    public class ScrapingHelper
    {
        private IWebDriver Driver { get; set; }
        private WebDriverWait Wait { get; set; }
        private DecisaoModel Decisao { get; set; }

        private By NextPage = By.CssSelector("a.esajLinkLogin[title='Próxima página']");

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
                throw new Exception(msg);
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

        public bool AreAllPresent(By by)
        {
            try
            {
                if (!String.IsNullOrEmpty(Driver.CurrentWindowHandle))
                {
                    try
                    {
                        //Driver.FindElement(by); ---------->> possivelmente desnecessário
                        Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
                        return true; // Para sair do loop em condições normais
                    }
                    catch (Exception)
                    {
                        return false; // Para se manter no loop
                    }
                }
                else
                {
                    return true; // Este true serve para sair do loop, caso haja um erro
                }
            }
            catch (Exception)
            {
                return true; // Este true serve para sair do loop, caso haja um erro
            }
        }

        private void IsInteractable(By by)
        {
            if (!String.IsNullOrEmpty(Driver.CurrentWindowHandle))
            {
                int tries = 0;
                bool waiting;
                do
                {
                    waiting = AreAllPresent(by);
                    if (!waiting)
                    {
                        tries++;
                    }

                    if (tries > 3)
                    {
                        ProximaPagina(NextPage);
                        tries = 0;
                    }
                } while (!waiting);
            }
            else
            {
                throw new Exception();
            }
        }

        public void IsLoaded(By by)
        {
            try
            {
                IsInteractable(by);
            }
            catch (Exception)
            {
                //Driver.Quit();
                throw new Exception("Site demorou muito para carregar ou foi fechado!");
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements(By element)
        {
            if(!String.IsNullOrEmpty(Driver.CurrentWindowHandle))
            {
                return Driver.FindElements(element);
            }
            else
            {
                throw new Exception("Elemento não encontrado!\nOu o site demorou muito para carregar ou foi fechado.");
            }
        }
        
        public bool FindAndClick(IWebElement table, By element)
        {
            try
            {
                if (!String.IsNullOrEmpty(Driver.CurrentWindowHandle))
                {
                    try
                    {
                        table.FindElement(element).Click();
                        return true; // Para sair do loop em condições normais
                    }
                    catch (Exception)
                    {
                        return false; // Para se manter no loop
                    }
                }
                else
                {
                    return true; // Para sair do loop, caso algo dê errado
                }
            }
            catch (Exception)
            {
                return true;  // Para sair do loop, caso algo dê errado
            }
        }

        public void ClickLoop(IWebElement table, By element)
        {
            if (!String.IsNullOrEmpty(Driver.CurrentWindowHandle))
            {
                bool clicked;
                do
                {
                    clicked = FindAndClick(table, element);
                } while (!clicked);
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
                    clicked = FindAndClick(tableElement, linkElement);
                } while (!clicked);

                SwitchTabGetLink(Decisao);
            }
        }

        public void ProximaPagina(By nextPageElement) //Colocar um loop aqui
        {
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

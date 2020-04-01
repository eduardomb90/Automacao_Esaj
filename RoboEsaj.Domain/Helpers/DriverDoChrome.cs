using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RoboEsaj.Domain.Helpers
{
    // Factory Method
    public static class DriverDoChrome
    {

        public static string GetChromeFolder() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        public static IWebDriver GetChrome()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArgument("no-sandbox");
                options.AddArgument("--start-maximized");

                return new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(240));
            }
            catch (Exception)
            {
                MessageBox.Show("O navegador Chrome não está instalado!", "Chrome ausente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
    }
}
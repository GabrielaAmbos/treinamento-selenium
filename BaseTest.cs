using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TreinamentoSelenium
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void BaseSetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void BaseTearDown()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;
        }

        public void AcessaUrl(IWebDriver Driver, string url = "https://test-sandbox.azurewebsites.net/")
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}

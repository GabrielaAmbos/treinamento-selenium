using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TreinamentoSelenium.Exemplos.PageObjects.Exemplos
{
    public class Atividade1PageObject : Helper
    {
        public Atividade1PageObject(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }


        [FindsBy(How = How.CssSelector, Using = "a[href*='coffee']")]
        public IWebElement NomeRestaurante { get; set; }


        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement Menu { get; set; }

        public string retornarNomeRestaurante(string restaurante)
		{
            
		}
    }
}

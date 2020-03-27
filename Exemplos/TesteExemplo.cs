using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TreinamentoSelenium.Exemplos
{
    [TestFixture]
    public class TesteExemplo
    {
        [Test]
        public void PersquisarNoGoogle()
        {
            //Inicializa o Driver
            IWebDriver Driver = new ChromeDriver();

            // Navega para a URL do Google
            Driver.Navigate().GoToUrl("https://google.com");

            // Busca o <input> de texto name "q"
            var elemento = Driver.FindElement(By.Name("q"));

            // Realiza uma pesquisa
            elemento.SendKeys("gvdasa");

            //Seleciona o valor "gvdasa na lista"
            var listaOpcoes = Driver.FindElement(By.CssSelector("ul[role='listbox']"));

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='gvdasa']")));

            listaOpcoes.FindElement(By.XPath("//span[text()='gvdasa']")).Click();

            wait.Until(d => d.Title.StartsWith("GVdasa", StringComparison.OrdinalIgnoreCase));

            // Verifica se abriu a aba conforme pesquisa realizada
            Assert.AreEqual("gvdasa - Pesquisa Google", Driver.Title);

            Driver.Close();
            Driver.Quit();
            Driver = null;
        }
    }
}

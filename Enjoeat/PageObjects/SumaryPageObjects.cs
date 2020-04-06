using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoSelenium.Enjoeat.PageObjects
{
    class SumaryPageObjects : Helper
    {
        public SumaryPageObjects(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        [FindsBy(How = How.CssSelector, Using = "h2")]
        public IWebElement InformacaoConcluido { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='jumbotron'] p:nth-child(2)")]
        public IWebElement Mensagem { get; set; }

        public IWebElement AvaliarPedido(int quant)
        {
            IWebElement estrelas = Driver.FindElement(By.CssSelector($"i.fa-star-o:nth-child({quant})"));
            return estrelas;
        }

        public IWebElement VerificarAvaliacao(int quant)
        {
            IWebElement estrelas = Driver.FindElement(By.CssSelector($"i.fa-star:nth-child({quant})"));
            return estrelas;
        }

        public string BuscarCor(string color)
        {
            string cor = "";
            switch (color)
            {
                case "Cinza":
                    cor = "rgba(85, 85, 85, 1)";
                    break;
                case "Branco":
                    cor = "rgba(255, 255, 255, 1)";
                    break;
                default:
                    break;
            }
            return cor;
        }


    }
}

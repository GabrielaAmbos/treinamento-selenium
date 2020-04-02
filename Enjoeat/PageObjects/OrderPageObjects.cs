using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoSelenium.Enjoeat.PageObjects
{
    class OrderPageObjects : Helper
    {
        public OrderPageObjects(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='name']")]
        public IWebElement CampoNome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='email']")]
        public IWebElement CampoEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='emailConfirmation']")]
        public IWebElement CampoConfirmarEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='address']")]
        public IWebElement CampoEndereco { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='number']")]
        public IWebElement CampoNumero { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='optionalAddress']")]
        public IWebElement CampoComplemento { get; set; }


        private IWebElement BuscarElementoFormaDePagamento(int posicao)
        {

            IWebElement elemento = Driver.FindElement(By.CssSelector($"mt-radio[formcontrolname] > div:nth-child({posicao})"));
            return elemento;
        }

        public IWebElement RetornarFormaDePagamento(string formaDePagamento)
        {
            int posicao = BuscarPosicaoDaOpcaoDePagamento(formaDePagamento);

            IWebElement elementoItem = BuscarElementoFormaDePagamento(posicao);

            return elementoItem;
        }


        public int BuscarPosicaoDaOpcaoDePagamento(string opcao)
        {
            int posicao = 0;

            switch (opcao)
            {
                case "Dinheiro":
                    posicao = 1;
                    break;
                case "Cartão de Débito":
                    posicao = 2;
                    break;
                case "Cartão Refeição":
                    posicao = 3;
                    break;

                default:
                    break;
            }
            return posicao;
        }
    }
}

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

        [FindsBy(How = How.CssSelector, Using = "tbody:nth-child(2) tr:nth-child(1) td:nth-child(1) a:nth-child(1)")]
        public IWebElement RemoverClassicBurguer { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        public IWebElement FinalizarPedido { get; set; }

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

        private IWebElement BuscarFreteEPagamento(int posicao)
        {
            IWebElement freteEPagamento = Driver.FindElement(By.CssSelector($"tbody:nth-child(1) tr:nth-child({posicao})"));
            return freteEPagamento;
        }

        public string RetornarPreco(string opcao)
        {
            string precoEncontrado;
            int posicao = BuscarPosicaoDoFreteEPagamento(opcao);

            var elementoItem = BuscarFreteEPagamento(posicao);
            precoEncontrado = elementoItem.FindElement(By.CssSelector(" td")).Text;

            return precoEncontrado;
        }

        public int BuscarPosicaoDoFreteEPagamento(string opcao)
        {
            int posicao = 0;

            switch (opcao)
            {
                case "Itens":
                    posicao = 1;
                    break;
                case "Frete":
                    posicao = 2;
                    break;
                case "Valor Total":
                    posicao = 3;
                    break;
                default:
                    break;
            }
            return posicao;
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

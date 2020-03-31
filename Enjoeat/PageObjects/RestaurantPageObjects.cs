using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoSelenium.Enjoeat.PageObjects
{
    public class RestaurantPageObjects : Helper
    {
        public RestaurantPageObjects(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        [FindsBy(How = How.CssSelector, Using = "tr:nth-child(2) td[class='text-right']:nth-child(2)")]
        public IWebElement TotalCarrinho { get; set; }

        private IWebElement BuscarElementoItem(int posicao)
        {
            IWebElement elementoItem = Driver.FindElement(By.CssSelector($"mt-menu-item:nth-child({posicao}) > div.menu-item-info-box"));
            return elementoItem;
        }
        public string RetornarItem(string item)
        {
            string itemEncontrado;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            itemEncontrado = elementoItem.FindElement(By.CssSelector("span[class='menu-item-info-box-text']")).Text;

            return itemEncontrado;
        }
        public string RetornarPreco(string item)
        {
            string precoEncontrado;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            precoEncontrado = elementoItem.FindElement(By.CssSelector("span[class='menu-item-info-box-price']:nth-child(3)")).Text;

            return precoEncontrado;
        }
        public string RetornarDescricaoDoItem(string item)
        {
            string descricaoEncontrada;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            descricaoEncontrada = elementoItem.FindElement(By.CssSelector("span:nth-child(2)")).Text;

            return descricaoEncontrada;
        }

        public IWebElement adicionarItemAoCarrinho(string item)
        {
            IWebElement botaoEncontrado;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            botaoEncontrado = elementoItem.FindElement(By.CssSelector("a[class='add-to-cart']"));
            
            return botaoEncontrado;
        }

        public int BuscarPosicaoDoItem(string nomeItem)
        {
            int posicao = 0;
            switch (nomeItem.ToUpper())
            {
                case "CAPPUCCINO COM CHANTILLY":
                case "CUP CAKE":
                case "CUP CAKE DE CHOC. BRANCO":
                case "SUCO DETOX":
                    posicao = 1;
                    break;
                case "SUPER EXPRESSO":
                case "DONUT":
                case "BOLO DE MORANGO":
                case "HAMBURGER DE QUINOA":
                    posicao = 2;
                    break;
                case "STARBUCKS COPYCAT":
                case "PÃO ARTESANAL ITALIANO":
                case "FATIA DE BOLO":
                case "SALADA CEASAR":
                    posicao = 3;
                    break;

                default: break;
            }
            return posicao;
        }

    }
}

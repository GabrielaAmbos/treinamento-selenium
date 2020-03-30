using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TreinamentoSelenium.Exemplos.PageObjects.Exemplos
{
    public class CoffeeCorderPageObject : Helper
    {
        public CoffeeCorderPageObject(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        private IWebElement BuscarElementoItem(int posicao)
        {
            IWebElement elementoItem = Driver.FindElement(By.CssSelector($"mt-menu-item:nth-child({posicao}) > div.menu-item-info-box"));
            return elementoItem;
        }

        public string RetornarDescricaoDoItem(string item)
        {
            string descricaoEncontrada;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            descricaoEncontrada = elementoItem.FindElement(By.CssSelector("span:nth-child(2)")).Text;

            return descricaoEncontrada;
        }

        public string RetornarPreco(string item)
        {
            string precoEncontrado;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            precoEncontrado = elementoItem.FindElement(By.CssSelector("span[class='menu-item-info-box-price']:nth-child(3)")).Text;

            return precoEncontrado;
        }

        public string RetornarItem(string item)
        {
            string itemEncontrado;
            int posicao = BuscarPosicaoDoItem(item);

            var elementoItem = BuscarElementoItem(posicao);
            itemEncontrado = elementoItem.FindElement(By.CssSelector("span[class='menu-item-info-box-text']")).Text;

            return itemEncontrado;
        }

        public int BuscarPosicaoDoItem(string nomeItem)
        {
            int posicao = 0;
            switch (nomeItem.ToUpper())
            {
                case "CAPPUCCINO COM CHANTILLY":
                    posicao = 1;
                    break;
                case "SUPER EXPRESSO":
                    posicao = 2;
                    break;
                case "STARBUCKS COPYCAT":
                    posicao = 3;
                    break;

                default: break;
            }
            return posicao;
        }
    }
}

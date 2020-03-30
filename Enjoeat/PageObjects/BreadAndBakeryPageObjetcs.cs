using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoSelenium.Enjoeat.PageObjects
{
    class BreadAndBakeryPageObjetcs : Helper
    {
        public BreadAndBakeryPageObjetcs(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        private IWebElement BuscarElementoItem(int posicao)
        {
            IWebElement elementoItem = Driver.FindElement(By.CssSelector($"mt-menu-item:nth-child({posicao}) > div.menu-item-info-box"));
            return elementoItem;
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
                case "CUP CAKE":
                    posicao = 1;
                    break;
                case "DONUT":
                    posicao = 2;
                    break;
                case "PÃO ARTESANAL ITALIANO":
                    posicao = 3;
                    break;

                default: break;
            }
            return posicao;
        }

    }
}

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


        [FindsBy(How = How.CssSelector, Using = "div#restaurant > div.box-header > h3.box-title")]
        public IWebElement NomeRestaurant { get; set; }

        public int BuscarPosicao(string nomeItem)
        {
            int posicao = 0;
            switch (nomeItem)
            {
                case "CAPPUCCINO COM CHANTILLY":
                    posicao = 1;
                    break;
                case "SUPER ESPRESO":
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

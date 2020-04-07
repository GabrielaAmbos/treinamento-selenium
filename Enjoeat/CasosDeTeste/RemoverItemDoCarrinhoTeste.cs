using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TreinamentoSelenium.Enjoeat.PageObjects;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;
using Assert = NUnit.Framework.Assert;

namespace TreinamentoSelenium.Enjoeat.CasosDeTeste
{
    [TestFixture]
    public class RemoverItemDoCarrinhoTeste : BaseTest
    {
        [Test]
        public void RemoverItemDoCarrinho()
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);

            enjoeatPageObject.IrparaRestaurante("Green Food").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Green Food", enjoeatPageObject.NomeRestaurant.Text);

            restaurantPageObjects.adicionarItemAoCarrinho("Suco Detox").Click();

            for (int i = 0; i < 2; i++)
            { 
                restaurantPageObjects.adicionarItemAoCarrinho("Salada Ceasar").Click();
            }
                
            Assert.AreEqual("R$ 19,90", restaurantPageObjects.TotalCarrinho.Text);

            restaurantPageObjects.PrimeiroItemDoCarrinho().Click();

            Assert.AreEqual("R$ 21,90", restaurantPageObjects.TotalCarrinho.Text);
        }
    }
}

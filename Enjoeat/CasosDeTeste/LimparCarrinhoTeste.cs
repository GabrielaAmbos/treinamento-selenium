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
    public class LimparCarrinhoTeste : BaseTest
    {
        [Test]
        public void LimparCarrinho()
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);

            enjoeatPageObject.IrparaRestaurante("Tasty Treats").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Tasty Treats", enjoeatPageObject.NomeRestaurant.Text);

            restaurantPageObjects.adicionarItemAoCarrinho("Bolo de Morango").Click();

            for(int i = 0; i < 3; i++)
            {
                restaurantPageObjects.adicionarItemAoCarrinho("Cup Cake de Choc. Branco").Click();
            }

            Assert.AreEqual("R$ 57,00", restaurantPageObjects.TotalCarrinho.Text);

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='box-footer']:last-child")));

            restaurantPageObjects.BotaoLimpar.Click();

            Assert.AreEqual("Seu carrinho está vazio!", restaurantPageObjects.FraseDoCarrinho.Text);

        }
    }
}

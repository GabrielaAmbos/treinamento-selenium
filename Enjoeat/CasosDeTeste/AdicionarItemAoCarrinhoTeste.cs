using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TreinamentoSelenium.Enjoeat.PageObjects;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;
using Assert = NUnit.Framework.Assert;

namespace TreinamentoSelenium.Enjoeat.CasosDeTeste
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class AdicionarItemAoCarrinhoTeste : BaseTest
    {
        [Test]
        public void AdicionarItemAoCarrinho()
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);

            enjoeatPageObject.IrparaRestaurante("Bread & Bakery").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Bread & Bakery", enjoeatPageObject.NomeRestaurant.Text);

            restaurantPageObjects.adicionarItemAoCarrinho("Pão artesanal italiano").Click();

            Assert.AreEqual("R$ 12,90", restaurantPageObjects.TotalCarrinho.Text);
        }

        [Test]
        public void AdicionarItensAoCarrinho()
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);

            enjoeatPageObject.IrparaRestaurante("Bread & Bakery").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Bread & Bakery", enjoeatPageObject.NomeRestaurant.Text);

            restaurantPageObjects.adicionarItemAoCarrinho("Pão artesanal italiano").Click();
            for (int i = 0; i < 2; i++)
            { 
                restaurantPageObjects.adicionarItemAoCarrinho("Cup Cake").Click();
            }
                
            Assert.AreEqual("R$ 19,90", restaurantPageObjects.TotalCarrinho.Text);
        }
    }
}

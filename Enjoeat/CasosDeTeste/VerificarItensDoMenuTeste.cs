using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TreinamentoSelenium.Enjoeat.PageObjects;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;

namespace TreinamentoSelenium.Enjoeat.CasosDeTeste
{
    [TestFixture]
    public class VerificarItensDoMenuTeste : BaseTest
    {
        [Test]
        public void VerificarItensDoMenu()
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);

            enjoeatPageObject.IrparaRestaurante("Coffee Corner").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Coffee Corner", enjoeatPageObject.NomeRestaurant.Text);

            List<string> listaItens = new List<string>();
            listaItens.Add("CAPPUCCINO COM CHANTILLY");
            listaItens.Add("SUPER EXPRESSO");
            listaItens.Add("STARBUCKS COPYCAT");

            List<string> listaDescricoes = new List<string>();
            listaDescricoes.Add("Tradicional cappuccino com chantilly");
            listaDescricoes.Add("Café expresso duplo.");
            listaDescricoes.Add("O mais pedido da casa. O verdadeiro café americano pura água.");

            List<string> listaPreco = new List<string>();
            listaPreco.Add("R$ 9,90");
            listaPreco.Add("R$ 12,50");
            listaPreco.Add("R$ 15,60");

            for (int i = 0; i < listaItens.Count; i++)
            {
                string valorNomeItem = listaItens[i].ToUpper();
                string valorDescricao = listaDescricoes[i];
                string valorPreco = listaPreco[i];

                Assert.AreEqual(valorNomeItem, restaurantPageObjects.RetornarItem(valorNomeItem));
                Assert.AreEqual(valorDescricao, restaurantPageObjects.RetornarDescricaoDoItem(valorNomeItem));
                Assert.AreEqual(valorPreco, restaurantPageObjects.RetornarPreco(valorNomeItem));
            }
        }
    }
}

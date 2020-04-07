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
    public class FecharPedidoTeste : BaseTest
    {
        [Test]
        public void FecharPedido()
        {
            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            RestaurantPageObjects restaurantPageObjects = new RestaurantPageObjects(Driver);
            OrderPageObjects orderPageObjects = new OrderPageObjects(Driver);
            SumaryPageObjects sumaryPageObjects = new SumaryPageObjects(Driver);

            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");

            enjoeatPageObject.IrparaRestaurante("Burger House").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual("Burger House", enjoeatPageObject.NomeRestaurant.Text);

            for (int i = 0; i < 2; i++)
            {
                restaurantPageObjects.adicionarItemAoCarrinho("Classic Burger").Click();
            }

            for (int i = 0; i < 2; i++)
            {
                restaurantPageObjects.adicionarItemAoCarrinho("Batatas fritas").Click();
            }

            for (int i = 0; i < 3; i++)
            {
                restaurantPageObjects.adicionarItemAoCarrinho("Refrigerante").Click();
            }

            Assert.AreEqual("R$ 61,50", restaurantPageObjects.TotalCarrinho.Text);

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='box-footer']:last-child")));
            restaurantPageObjects.BotaoConfirmar.Click();

            orderPageObjects.CampoNome.SendKeys("Comprador teste");
            orderPageObjects.CampoEmail.SendKeys("compradorteste@teste.com");
            orderPageObjects.CampoConfirmarEmail.SendKeys("compradorteste@teste.com");

            orderPageObjects.CampoEndereco.SendKeys("Rua Tal");
            orderPageObjects.CampoNumero.SendKeys("123");
            orderPageObjects.CampoComplemento.SendKeys("apto. 45");

            IWebElement pagamentoItem = orderPageObjects.RetornarFormaDePagamento("Cartão de Débito");
            pagamentoItem.FindElement(By.CssSelector("div")).Click();
            Assert.AreEqual("Cartão de Débito", pagamentoItem.FindElement(By.CssSelector("label")).Text);

            Assert.AreEqual("R$ 61,50", orderPageObjects.RetornarPreco("Itens"));
            Assert.AreEqual("8,00", orderPageObjects.RetornarPreco("Frete").Replace("R$ ", ""));
            Assert.AreEqual("69,50", orderPageObjects.RetornarPreco("Valor Total").Replace("R$ ", ""));

            orderPageObjects.RemoverClassicBurguer.Click();

            Assert.AreEqual("R$ 43,00", orderPageObjects.RetornarPreco("Itens"));
            Assert.AreEqual("8,00", orderPageObjects.RetornarPreco("Frete").Replace("R$ ", ""));
            Assert.AreEqual("51,00", orderPageObjects.RetornarPreco("Valor Total").Replace("R$ ", ""));

            orderPageObjects.FinalizarPedido.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("i.fa-star-o")));

            Assert.AreEqual("Pedido foi Concluído", sumaryPageObjects.InformacaoConcluido.Text);

            Assert.AreEqual("Seu pedido foi recebido pelo restaurante. Prepare a mesa que a comida está chegando!", sumaryPageObjects.Mensagem.Text);

            sumaryPageObjects.AvaliarPedido(4).Click();

            var verificaEstrela = sumaryPageObjects.VerificarAvaliacao(4);

            Assert.AreEqual(sumaryPageObjects.BuscarCor("Cinza"), verificaEstrela.GetCssValue("color"));

        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;

namespace TreinamentoSelenium.Exemplos.CasosDeTeste
{
    [TestFixture]
    public class Exemplo1SemBDDTeste : BaseTest
    {
        [Test]
        public void Exemplo1SemBDD()
        {
               
            new BaseTest().AcessaUrl(Driver);

            EnjoeatPageObject enjoeatPageObject = new EnjoeatPageObject(Driver);
            Assert.IsTrue(enjoeatPageObject.RetornarSeLogoExiste());
            Assert.AreEqual("Delivery pra qualquer fome: peça e receba em casa", enjoeatPageObject.RetornarTextoDescricao());
            enjoeatPageObject.BotaoRestaurantes.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='col-sm-6 col-xs-12']:nth-child(1)  span[class='place-info-box-icon']")));

            List<string> listaRestaurantes = new List<string>();
            listaRestaurantes.Add("Bread & Bakery");
            listaRestaurantes.Add("Burger House");
            listaRestaurantes.Add("Coffee Corner");
            listaRestaurantes.Add("Green Food");
            listaRestaurantes.Add("Ice Cream");
            listaRestaurantes.Add("Tasty Treats");


            List<string> listaDescricoes = new List<string>();
            listaDescricoes.Add("Padaria");
            listaDescricoes.Add("Hamburgers");
            listaDescricoes.Add("Cafeteria");
            listaDescricoes.Add("Saudável");
            listaDescricoes.Add("Sorvetes");
            listaDescricoes.Add("Doces");

            List<string> listaTempos = new List<string>();
            listaTempos.Add("25 minutos");
            listaTempos.Add("30 minutos");
            listaTempos.Add("20 minutos");
            listaTempos.Add("40 minutos");
            listaTempos.Add("1 hora");
            listaTempos.Add("20 minutos");

            List<string> listaClassificacoes = new List<string>();
            listaClassificacoes.Add("4.9");
            listaClassificacoes.Add("3.5");
            listaClassificacoes.Add("4.8");
            listaClassificacoes.Add("4.1");
            listaClassificacoes.Add("0");
            listaClassificacoes.Add("4.4");


            for (int rest = 0, descricao = 0, tempo = 0, classificacao = 0; rest < listaRestaurantes.Count; rest++, descricao++, tempo++, classificacao++)
            {
                string valorRestaurante = listaRestaurantes[rest].ToUpper();
                string valorDescricao = listaDescricoes[descricao];
                string valorTempos = listaTempos[tempo];
                string valorClassicicacao = listaClassificacoes[classificacao];

                Assert.AreEqual(valorRestaurante, enjoeatPageObject.RetornarRestaurante(valorRestaurante));
                Assert.AreEqual(valorDescricao, enjoeatPageObject.RetornarDescricaoRestaurante(valorRestaurante));
                Assert.AreEqual(valorTempos, enjoeatPageObject.RetornarTempo(valorRestaurante));
                Assert.AreEqual(valorClassicicacao, enjoeatPageObject.RetornarClassificacao(valorRestaurante));
            }

        }
            
    }
}

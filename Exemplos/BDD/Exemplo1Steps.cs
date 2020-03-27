using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;

namespace TreinamentoSelenium.Exemplos.BDD
{
    [Binding]
    public class Exemplo1Steps
    {
        private readonly IWebDriver Driver = ScenarioContext.Current.Get<IWebDriver>();
        private EnjoeatPageObject _enjoeatPageObject;
        private EnjoeatPageObject enjoeatPageObject
        {
            get
            {
                if (_enjoeatPageObject == null)
                {
                    _enjoeatPageObject = new EnjoeatPageObject(Driver);
                }

                return _enjoeatPageObject;
            }
        }

        [Given(@"que acesso o Enjoeat")]
        public void GivenQueAcessoOEnjoeat()
        {
            new BaseTest().AcessaUrl(Driver);

            Assert.IsTrue(enjoeatPageObject.RetornarSeLogoExiste());
            Assert.AreEqual("Delivery pra qualquer fome: peça e receba em casa",_enjoeatPageObject.RetornarTextoDescricao());
        }

        [When(@"solicito a lista de restaurantes")]
        public void WhenSolicitoAListaDeRestaurantes()
        {
            enjoeatPageObject.BotaoRestaurantes.Click();
        }


        [Then(@"exibe uma lista com os restaurantes e suas informações disponíveis")]
        public void ThenExibeUmaListaComOsRestaurantesESuasInformacoesDisponiveis(Table listaRestaurantes)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='col-sm-6 col-xs-12']:nth-child(1)  span[class='place-info-box-icon']")));
            
            foreach (var row in listaRestaurantes.Rows)
            {
                string restaurante = row["Restaurante"].ToUpper();
                string descricao = row["Descricao"];
                string tempo = row["Tempo"];
                string classificacao = row["Classificação"];

                Assert.AreEqual(restaurante, enjoeatPageObject.RetornarRestaurante(restaurante));
                Assert.AreEqual(descricao, enjoeatPageObject.RetornarDescricaoRestaurante(restaurante));
                Assert.AreEqual(tempo, enjoeatPageObject.RetornarTempo(restaurante));
                Assert.AreEqual(classificacao, enjoeatPageObject.RetornarClassificacao(restaurante));
            }
        }

    }
}

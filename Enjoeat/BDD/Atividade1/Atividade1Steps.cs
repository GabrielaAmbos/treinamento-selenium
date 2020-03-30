using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;

namespace TreinamentoSelenium.Enjoeat.BDD.Atividade1
{
    [Binding]
    public class Atividade1Steps
    {
        private readonly IWebDriver Driver = ScenarioContext.Current.Get<IWebDriver>();
        private CoffeeCorderPageObject _coffeCornerPageObject;
        private CoffeeCorderPageObject coffeeCornerPageObject
        {
            get
            {
                if(_coffeCornerPageObject == null)
                {
                    _coffeCornerPageObject = new CoffeeCorderPageObject(Driver);
                }
                return _coffeCornerPageObject;
            }
        }
        private EnjoeatPageObject _enjoeatPageObject;
        private EnjoeatPageObject enjoeatPageObject
        {
            get
            {
                if(_enjoeatPageObject == null)
                {
                    _enjoeatPageObject = new EnjoeatPageObject(Driver);
                }
                return _enjoeatPageObject;
            }
        }


        #region Cenário: Verificar itens do menu
        [Given(@"que escolho comprar do ""(.*)""")]
        public void DadoQueEscolhoComprarDo(string nomeRestaurante)
        {
            new BaseTest().AcessaUrl(Driver, "https://test-sandbox.azurewebsites.net/restaurants/");
            enjoeatPageObject.IrparaRestaurante(nomeRestaurante).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img.box-img-detail")));

            Assert.AreEqual(nomeRestaurante, enjoeatPageObject.NomeRestaurant.Text);
        }

        [When(@"eu vejo o menu")]
        public void QuandoEuVejoOMenu()
        {
           //talvez não vá codigo aqui
           
            //Colocar um assert aqui
        }

        [Then(@"eu visualizo os itens")]
        public void EntaoEuVisualizoOsItens(Table ItemsParaComprar)
        {
            foreach (var row in ItemsParaComprar.Rows)
            {
                string nomeItem = row["Nome"].ToUpper();
                string descricao = row["Descrição"];
                string preco = row["Valor"];

                Assert.AreEqual(nomeItem, coffeeCornerPageObject.RetornarItem(nomeItem));
                Assert.AreEqual(descricao, coffeeCornerPageObject.RetornarDescricaoDoItem(nomeItem));
                Assert.AreEqual(preco, coffeeCornerPageObject.RetornarPreco(nomeItem));
            }
        }
        #endregion

        #region Cenário: Adicionar item ao carrinho
        [When(@"eu adiciono (.*) ""(.*)""")]
        public void QuandoEuAdiciono(int p0, string p1)
        {
            
        }

        [Then(@"exibe o valor total de ""(.*)""")]
        public void EntaoExibeOValorTotalDe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion

        #region Cenário: Adicionar itens ao carrinho

        #endregion

        #region Cenário: Remover item do carrinho
        [When(@"removo o ""(.*)"" do carrinho")]
        public void QuandoRemovoODoCarrinho(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion

        #region Cenário: Limpar carrinho
        [When(@"eu limpo o carrinho")]
        public void QuandoEuLimpoOCarrinho()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"vejo no carrinho a m ensagem ""(.*)""")]
        public void EntaoVejoNoCarrinhoAMEnsagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion

        #region Cenário: Fechar pedido
        [When(@"eu fecho o pedido")]
        public void QuandoEuFechoOPedido()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"eu preencho os dados (.*), (.*), (.*)")]
        public void EntaoEuPreenchoOsDados(string p0, string p1, string p2, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"preencho o endereço de entrega")]
        public void EntaoPreenchoOEnderecoDeEntrega(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"opto pelo pagamento com ""(.*)""")]
        public void EntaoOptoPeloPagamentoCom(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"exibe o os valores")]
        public void EntaoExibeOOsValores(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"eu removo (.*) ""Classic Burger")]
        public void QuandoEuRemovoClassicBurger(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"eu finalizo o pedido")]
        public void QuandoEuFinalizoOPedido()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"sou informado que o ""(.*)""")]
        public void EntaoSouInformadoQueO(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"vejo a mensagem ""(.*)""")]
        public void EntaoVejoAMensagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"e avalio a experiência com (.*) estrelas")]
        public void QuandoEAvalioAExperienciaComEstrelas(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"(.*) estrelas ficam com a cor ""(.*)""")]
        public void EntaoEstrelasFicamComACor(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TreinamentoSelenium.Enjoeat.PageObjects;
using TreinamentoSelenium.Exemplos.PageObjects.Exemplos;

namespace TreinamentoSelenium.Enjoeat.BDD.Atividade1
{
    [Binding]
    public class Atividade1Steps
    {
        private readonly IWebDriver Driver = ScenarioContext.Current.Get<IWebDriver>();

        private RestaurantPageObjects _restaurantPageObject;
        private RestaurantPageObjects restaurantPageObject
        {
            get
            {
                if(_restaurantPageObject == null)
                {
                    _restaurantPageObject = new RestaurantPageObjects(Driver);
                }
                return _restaurantPageObject;
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

        private OrderPageObjects _orderPageObjects;
        private OrderPageObjects orderPageObjects
        {
            get
            {
                if(_orderPageObjects == null)
                {
                    _orderPageObjects = new OrderPageObjects(Driver);
                }
                return _orderPageObjects;
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

                Assert.AreEqual(nomeItem, restaurantPageObject.RetornarItem(nomeItem));
                Assert.AreEqual(descricao, restaurantPageObject.RetornarDescricaoDoItem(nomeItem));
                Assert.AreEqual(preco, restaurantPageObject.RetornarPreco(nomeItem));
            }
        }
        #endregion

        #region Cenário: Adicionar item ao carrinho
        [When(@"eu adiciono (.*) ""(.*)""")]
        public void QuandoEuAdiciono(int quantidade, string item)
        {
            for(int i = 0; i < quantidade; i++)
            {
                restaurantPageObject.adicionarItemAoCarrinho(item).Click();
            }

            Assert.AreEqual(item.ToUpper(), restaurantPageObject.RetornarItem(item));
        }

        [Then(@"exibe o valor total de ""(.*)""")]
        public void EntaoExibeOValorTotalDe(string precoTotal)
        {
            Assert.AreEqual(precoTotal, restaurantPageObject.TotalCarrinho.Text);
        }

        #endregion

        #region Cenário: Adicionar itens ao carrinho

        #endregion

        #region Cenário: Remover item do carrinho
        [When(@"removo o ""(.*)"" do carrinho")]
        public void QuandoRemovoODoCarrinho(string nomeItem)
        {
            //REFAZER
            //Fazer assertiva
            restaurantPageObject.PrimeiroItemDoCarrinho().Click();
        }

        #endregion

        #region Cenário: Limpar carrinho

        [When(@"eu limpo o carrinho")]
        public void QuandoEuLimpoOCarrinho()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='box-footer']:last-child")));

            restaurantPageObject.BotaoLimpar.Click();
        }

        [Then(@"vejo no carrinho a mensagem ""(.*)""")]
        public void EntaoVejoNoCarrinhoAMEnsagem(string fraseDoCarrinho)
        {
            Assert.AreEqual(fraseDoCarrinho, restaurantPageObject.FraseDoCarrinho.Text);
        }

        #endregion

        #region Cenário: Fechar pedido
        [When(@"eu fecho o pedido")]
        public void QuandoEuFechoOPedido()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='box-footer']:last-child")));
            restaurantPageObject.BotaoConfirmar.Click();

        }

        [Then(@"eu preencho os dados")]
        public void EntaoEuPreenchoOsDados(Table dadosCadastrais)
        {
            foreach(var row in dadosCadastrais.Rows)
            {
                string nome = row["Nome"];
                orderPageObjects.CampoNome.SendKeys(nome);
                string email = row["E-mail"];
                orderPageObjects.CampoEmail.SendKeys(email);
                string confirmarEmail = row["Confirmação do e-mail"];
                orderPageObjects.CampoConfirmarEmail.SendKeys(confirmarEmail);
            }
        }

        [Then(@"preencho o endereço de entrega")]
        public void EntaoPreenchoOEnderecoDeEntrega(Table enderecoEntrega)
        {
           foreach(var row in enderecoEntrega.Rows)
            {
                string endereco = row["Endereço"];
                orderPageObjects.CampoEndereco.SendKeys(endereco);
                string numero = row["Número"];
                orderPageObjects.CampoNumero.SendKeys(numero);
                string complemento = row["Complemento"];
                orderPageObjects.CampoComplemento.SendKeys(complemento);
            }
        }

        [Then(@"opto pelo pagamento com ""(.*)""")]
        public void EntaoOptoPeloPagamentoCom(string formaDePagamento)
        {
            IWebElement pagamentoItem = orderPageObjects.RetornarFormaDePagamento(formaDePagamento);

            pagamentoItem.FindElement(By.CssSelector("div")).Click();

            Assert.AreEqual(formaDePagamento, pagamentoItem.FindElement(By.CssSelector("label")).Text);
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

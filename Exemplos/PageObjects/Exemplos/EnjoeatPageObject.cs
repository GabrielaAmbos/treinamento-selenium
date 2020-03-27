using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TreinamentoSelenium.Exemplos.PageObjects.Exemplos
{
    public class EnjoeatPageObject : Helper
    {
        public EnjoeatPageObject(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }


        [FindsBy(How = How.CssSelector, Using = "img[source='/assets/img/logo-gray.png']")]
        public IWebElement LogoEnjoeat { get; set; }

        
        [FindsBy(How = How.CssSelector, Using = "div[class='jumbotron welcome-jumbotron'] p")]
        public IWebElement Descricao { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[class='btn btn-danger btn-lg']")]
        public IWebElement BotaoRestaurantes { get; set; }


        public bool RetornarSeLogoExiste()
        {
            var logoExiste = false;
                      

            if (LogoEnjoeat != null)
            {
                logoExiste = true;
            }

            return logoExiste;
        
        }

        public string RetornarTextoDescricao()
        {
            var textoDescricaoEncontrado = Descricao.Text.Replace("\r\n", " ");

            return textoDescricaoEncontrado;
        }

        private IWebElement BuscarElementorestaurante(int posicao)
        {

            IWebElement elementoRestaurante = Driver.FindElement(By.CssSelector($"div[class='col-sm-6 col-xs-12']:nth-child({posicao})"));
            return elementoRestaurante;
        }

        public string RetornarRestaurante(string restaurante)
        {
            string restauranteEncontrado;
            int posicao = BuscarPosicao(restaurante);

            var elementoRestaturante = BuscarElementorestaurante(posicao);
            restauranteEncontrado = elementoRestaturante.FindElement(By.CssSelector("span[class='place-info-box-text']")).Text;
                       
            return restauranteEncontrado;
        }

        public string RetornarDescricaoRestaurante(string restaurante)
        {
            string descricaoRestauranteEncontrada;
            int posicao = BuscarPosicao(restaurante);

            var elementoRestaturante = BuscarElementorestaurante(posicao);
            descricaoRestauranteEncontrada = elementoRestaturante.FindElement(By.CssSelector("span:nth-child(3)")).Text;


            return descricaoRestauranteEncontrada;
        }
        
        public string RetornarTempo(string restaurante)
        {
            string tempoEncontrado;
            int posicao = BuscarPosicao(restaurante);

            var elementoRestaturante = BuscarElementorestaurante(posicao);
            tempoEncontrado = elementoRestaturante.FindElement(By.CssSelector("span:nth-child(4)")).Text;


            return tempoEncontrado;
        }

        public string RetornarClassificacao(string restaurante)
        {
            string classificacaoEncontrada;
            int posicao = BuscarPosicao(restaurante);
            
            var elementoRestaturante = BuscarElementorestaurante(posicao);
            classificacaoEncontrada = elementoRestaturante.FindElement(By.CssSelector("span[class='place-info-box-star")).Text;

            return classificacaoEncontrada;
        }

        public int BuscarPosicao(string restaurante)
        {
            int posicao = 0;

            switch (restaurante)
            {
                case "BREAD & BAKERY":
                    posicao = 1;
                    break;
                case "BURGER HOUSE":
                    posicao = 2;
                    break;
                case "COFFEE CORNER":
                    posicao = 3;
                    break;
                case "GREEN FOOD":
                    posicao = 4;
                    break;
                case "ICE CREAM":
                    posicao = 5;
                    break;
                case "TASTY TREATS":
                    posicao = 6;
                    break;
                
                default:
                    break;
            }
            return posicao;
        }


    }
}

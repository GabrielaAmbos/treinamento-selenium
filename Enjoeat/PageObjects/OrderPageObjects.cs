using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoSelenium.Enjoeat.PageObjects
{
    class OrderPageObjects : Helper
    {
        public OrderPageObjects(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(Driver, TimeSpan.FromSeconds(60)));
        }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='name']")]
        public IWebElement CampoNome { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='email']")]
        public IWebElement CampoEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='emailConfirmation']")]
        public IWebElement CampoConfirmarEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='address']")]
        public IWebElement CampoEndereco { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='number']")]
        public IWebElement CampoNumero { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='optionalAddress']")]
        public IWebElement CampoComplemento { get; set; }
    }
}

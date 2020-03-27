using OpenQA.Selenium;
namespace TreinamentoSelenium
{
    public class Helper
    {
        public Helper(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; set; }

    }
}

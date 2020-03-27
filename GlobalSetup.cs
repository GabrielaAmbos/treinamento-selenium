using TechTalk.SpecFlow;

namespace TreinamentoSelenium
{
    [Binding]
    public class GlobalSetup
    {
        private BaseTest BaseTest { get; set; }

        [BeforeScenario]
        public void Setup()
        {
            BaseTest = new BaseTest();
            BaseTest.BaseSetUp();
            ScenarioContext.Current.Set(BaseTest.Driver);
        }

        [AfterScenario]
        public virtual void Cleanup()
        {
            BaseTest.BaseTearDown();
        }


    }
}

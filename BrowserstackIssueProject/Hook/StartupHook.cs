using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Edge;

namespace BrowserstackIssueProject.Hook
{
    [Binding]
    public class StartupHook
    {
        private readonly IObjectContainer testStepClassObjects;
        private IOSDriver mobileDriver;
        private WebDriver webDriver;

        public StartupHook(IObjectContainer objectContainer)
        {
            this.testStepClassObjects = objectContainer;
        }

        [BeforeScenario]
        public void SetupDriver()
        {
            mobileDriver = new IOSDriver(new Uri("http://127.0.0.1:4723/wd/hub"), new AppiumOptions());
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AcceptInsecureCertificates = true;
            webDriver = new EdgeDriver(edgeOptions);
            testStepClassObjects.RegisterInstanceAs(mobileDriver);
            testStepClassObjects.RegisterInstanceAs(webDriver);
        }

        [AfterScenario]
        public void Cleanup()
        {
            mobileDriver.Quit();
        }
    }
}

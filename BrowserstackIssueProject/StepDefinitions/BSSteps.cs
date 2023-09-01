using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;

namespace BrowserstackIssueProject.StepDefinitions
{
    [Binding]
    public class BSSteps
    {
        private readonly IOSDriver mobileWebDriver;
        private readonly WebDriver webDriver;

        public BSSteps(IOSDriver mobileWebDriver, WebDriver webDriver)
        {
            this.mobileWebDriver = mobileWebDriver;
            this.webDriver = webDriver;
        }

        [Given(@"Perform action in Sample Mobile App")]
        public void GivenPerformActionInSampleMobileApp()
        {
            Thread.Sleep(3000);
            AppiumElement textButton = mobileWebDriver.FindElement(MobileBy.AccessibilityId("Text Button"));
            textButton.Click();

            Thread.Sleep(3000);
            AppiumElement textInput = mobileWebDriver.FindElement(MobileBy.AccessibilityId("Text Input"));
            textInput.SendKeys("hello@browserstack.com" + "\n");

            Thread.Sleep(3000);
            AppiumElement textOutput = mobileWebDriver.FindElement(MobileBy.AccessibilityId("Text Output"));
            Assert.That("hello@browserstack.com", Is.EqualTo(textOutput.Text));
        }

        [Then(@"Open Google search in Local browser")]
        public void ThenOpenGoogleSearchInLocalBrowser()
        {
            webDriver.Navigate().GoToUrl("https://www.google.com");
        }

    }
}

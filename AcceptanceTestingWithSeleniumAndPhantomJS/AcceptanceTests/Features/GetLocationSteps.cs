using AcceptanceTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Features
{
    [Binding]
    public class GetLocationSteps
    {
        private GetLocationPage _page;

        public IWebDriver WebDriver
        {
            get { return ScenarioContext.Current["WebDriver"] as IWebDriver; }
        }

        [Given(@"I have opened the webpage")]
        public void GivenIHaveOpenedTheWebpage()
        {
            WebDriver.Url = "http://localhost:8080/";
            _page = PageFactory.InitElements<GetLocationPage>(WebDriver);
        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            //WebDriver.FindElement(By.Id("btnGetLocation")).Click();
            _page.GetCurrentLocation();
        }

        [Then(@"my ip should be visible on the screen")]
        public void ThenMyIpShouldBeVisibleOnTheScreen()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_page.IpAddress.Text));
        }

        [Then(@"my location should be visible on the screen")]
        public void ThenMyLocationShouldBeVisibleOnTheScreen()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_page.Latitude.Text));
            Assert.IsFalse(string.IsNullOrEmpty(_page.Longitude.Text));
        }

        [Then(@"the I should be able to click on button")]
        public void ThenTheIShouldBeAbleToClickOnButton()
        {
            Assert.AreEqual(true, _page.BtnGetLocation.Enabled);
        }

    }
}

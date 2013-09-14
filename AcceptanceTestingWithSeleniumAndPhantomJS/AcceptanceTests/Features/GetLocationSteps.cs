using System;
using AcceptanceTests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Features
{
    [Binding]
    public class GetLocationSteps
    {
        public IWebDriver WebDriver
        {
            get { return ScenarioContext.Current["WebDriver"] as IWebDriver; }
        }

        [Given(@"I have opened the webpage")]
        public void GivenIHaveOpenedTheWebpage()
        {
            WebDriver.Url = "http://localhost:8080/";
        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            WebDriver.FindElement(By.Id("btnGetLocation")).Click();
        }

        [Then(@"my ip should be visible on the screen")]
        public void ThenMyIpShouldBeVisibleOnTheScreen()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));

            wait.Until(BrowserConditions.AjaxIsFinished());
            var element = WebDriver.FindElement(By.Id("ip"));

            Assert.IsFalse(string.IsNullOrEmpty(element.Text));
        }

        [Then(@"my location should be visible on the screen")]
        public void ThenMyLocationShouldBeVisibleOnTheScreen()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));

            wait.Until(BrowserConditions.AjaxIsFinished());
            var latitude = WebDriver.FindElement(By.Id("latitude"));
            var longitude = WebDriver.FindElement(By.Id("longitude"));

            Assert.IsFalse(string.IsNullOrEmpty(latitude.Text));
            Assert.IsFalse(string.IsNullOrEmpty(longitude.Text));
        }
    }
}

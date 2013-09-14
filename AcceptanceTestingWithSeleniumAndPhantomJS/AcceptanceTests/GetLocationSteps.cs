using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AcceptanceTests
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
            //WebDriver.Url = "http://localhost:59832/";
            WebDriver.Url = "http://localhost:8080/";
        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            WebDriver.FindElement(By.Id("btnGetLocation")).Click();
        }
        
        [Then(@"my location should be visible on the screen")]
        public void ThenMyLocationShouldBeVisibleOnTheScreen()
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));

            wait.Until(BrowserConditions.AjaxIsFinished());
            var element = WebDriver.FindElement(By.Id("data"));

            Assert.IsFalse(string.IsNullOrEmpty(element.Text));
        }
    }
}

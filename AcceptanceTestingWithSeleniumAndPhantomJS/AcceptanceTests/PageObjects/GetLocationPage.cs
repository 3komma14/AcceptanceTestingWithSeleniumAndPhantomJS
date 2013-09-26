using System;
using AcceptanceTests.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTests.PageObjects
{
    public class GetLocationPage
    {
        private readonly IWebDriver _webDriver;

        [FindsBy(How = How.Id, Using = "btnGetLocation")] 
        public IWebElement BtnGetLocation;

        [FindsBy(How = How.Id, Using = "ip")] 
        public IWebElement IpAddress;

        [FindsBy(How = How.Id, Using = "latitude")] 
        public IWebElement Latitude;
        
        [FindsBy(How = How.XPath, Using = "//dd[position()=9]")] 
        public IWebElement Longitude;

        public GetLocationPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GetCurrentLocation()
        {
            BtnGetLocation.Click();
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
            wait.Until(BrowserConditions.AjaxIsFinished());
        }
    }
}

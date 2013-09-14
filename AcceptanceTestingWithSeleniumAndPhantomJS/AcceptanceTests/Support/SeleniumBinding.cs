using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Support
{
    [Binding]
    public class SeleniumBinding
    {
        private static IWebDriver _webdriver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _webdriver = CreatePhantomJSDriver();
            //_webdriver = CreateInternetExplorerDriver();
            Console.WriteLine("Created PhantomJSDriver");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Disposed PhantomJSDriver");
            _webdriver.Close();
            _webdriver.Dispose();
        }

        [BeforeScenario()]
        public static void BeforeScenario()
        {
            Console.WriteLine("Adding PhantomJSDriver to ScenarioContext");
            ScenarioContext.Current.Add("WebDriver", _webdriver);
        }

        [AfterScenario()]
        public static void AfterScenario()
        {
            Console.WriteLine("Removing PhantomJSDriver from ScenarioContext");
            ScenarioContext.Current.Remove("WebDriver");
        }

        private static IWebDriver CreatePhantomJSDriver()
        {
            var service = PhantomJSDriverService.CreateDefaultService();
            service.ProxyType = "none";
            //service.WebSecurity = false;
            //service.DiskCache = true;
            return new PhantomJSDriver(service);
        }

        private static IWebDriver CreateInternetExplorerDriver()
        {
            var options = new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
            return new InternetExplorerDriver(options);
        }
    }
}

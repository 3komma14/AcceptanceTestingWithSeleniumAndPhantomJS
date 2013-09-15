using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
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
            //_webdriver = CreateChromeDriver();
            //_webdriver = CreateFirefoxDriver();
            //_webdriver = CreateInternetExplorerDriver();
            Console.WriteLine("Created WebDriver");
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Disposed WebDriver");
            _webdriver.Close();
            _webdriver.Dispose();
        }

        [BeforeScenario()]
        public static void BeforeScenario()
        {
            Console.WriteLine("Adding WebDriver to ScenarioContext");
            ScenarioContext.Current.Add("WebDriver", _webdriver);
        }

        [AfterScenario()]
        public static void AfterScenario()
        {
            Console.WriteLine("Removing WebDriver from ScenarioContext");
            ScenarioContext.Current.Remove("WebDriver");
        }

        private static IWebDriver CreatePhantomJSDriver()
        {
            var service = PhantomJSDriverService.CreateDefaultService();
            service.ProxyType = "none";
            //service.WebSecurity = false;
            //service.DiskCache = true;
            //service.Port = 4444;
            return new PhantomJSDriver(service);
        }

        private static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private static IWebDriver CreateInternetExplorerDriver()
        {
            var options = new InternetExplorerOptions()
                              {
                                  IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                              };
            return new InternetExplorerDriver(options);
        }
    }
}

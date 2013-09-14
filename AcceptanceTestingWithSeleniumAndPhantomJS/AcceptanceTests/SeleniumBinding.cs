using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.PhantomJS;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class SeleniumBinding
    {
        private static PhantomJSDriver _webdriver;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _webdriver = new PhantomJSDriver();
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
    }
}

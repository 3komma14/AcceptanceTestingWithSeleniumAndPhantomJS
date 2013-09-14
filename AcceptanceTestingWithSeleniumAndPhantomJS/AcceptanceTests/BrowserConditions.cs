using System;
using OpenQA.Selenium;

namespace AcceptanceTests
{
    public class BrowserConditions
    {
        public static Func<IWebDriver, bool> AjaxIsFinished()
        {
            return (Func<IWebDriver, bool>)(driver =>
                                                {
                                                    Console.WriteLine("Waiting for ajax calls to finish");
                                                    return (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                                                });
        }
    }
}
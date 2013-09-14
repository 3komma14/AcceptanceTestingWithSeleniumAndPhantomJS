using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Support
{
    [Binding]
    public class IisExpressBinding
    {
        const string IisExpressPath = @"C:\Program Files (x86)\IIS Express\iisexpress.exe";
        private static volatile int _pid;

        [BeforeTestRun()]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Starting IISExpress");

            const string sitePath = @"C:\Projects\AcceptanceTestingWithSeleniumAndPhantomJS\AcceptanceTestingWithSeleniumAndPhantomJS\WebSite";
            const string sitePort = @"8080";

            _pid = StartIisExpress(sitePath, sitePort);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Stopping IISExpress");
            StopProcess(_pid);
        }


        private static int StartIisExpress(string sitePath, string sitePort)
        {
            var arguments = string.Format(@"/port:{1} /path:""{0}""", sitePath, sitePort);
            var startInfo = new ProcessStartInfo(IisExpressPath, arguments);
            // no window
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            // run
            var process = Process.Start(startInfo);
            return process.Id;
        }

        private static void StopProcess(int processId)
        {
            var process = Process.GetProcessById(processId);
            if (!process.HasExited)
            {
                process.Kill();
            }
        }
    }
}

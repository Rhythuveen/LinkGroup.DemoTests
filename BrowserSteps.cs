using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LinkGroup.DemoTests
{
    public sealed class BrowserSteps
    {
        //Implementing singleton pattern and Browser Factory

        private static IWebDriver browser;
        private static BrowserSteps BrowserStepsInstance = null;
        private BrowserSteps(string browserName, string options)
        {
            string testDirectory = TestContext.CurrentContext.TestDirectory;
            string ProjectPath = Regex.Split(testDirectory, "bin")[0];
            string ResourcePath = ProjectPath + "Resources\\Drivers";
            if (browserName.ToLower().Trim().Contains("chrome"))
            {
                browser = new ChromeDriver(ResourcePath);

            }

            //can extend to other browsers
        }
        public IWebDriver GetDriver()
        {
            return browser;
        }

        public static BrowserSteps getBrowserInstance(string browser, string options)
        {
            if (BrowserStepsInstance == null)
            {
                BrowserStepsInstance = new BrowserSteps(browser, options);

            }
            return BrowserStepsInstance;

        }
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests
{
    [Binding]

    public sealed class HooksFile
    {
        public static BrowserSteps browser;
        public static IWebDriver driver;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {




        }
        [BeforeFeature]
        public static void BeforeFeature()
        {

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            browser = BrowserSteps.getBrowserInstance("chrome", null);
            driver = browser.GetDriver();
            driver.Close();
            driver.Quit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Step_Definitions
{
    [Binding]
    class LinkFundStepDefnition
    {

        PageObjectModel.LinkFundHome fundObj;
        BrowserSteps browser;
        IWebDriver driver;

        [When(@"i open the Fund Solutions page")]
        public void WhenIOpenTheFundSolutionsPage()
        {
            try
            {
                browser = BrowserSteps.getBrowserInstance("chrome", null);
                driver = browser.GetDriver();
                fundObj = new PageObjectModel.LinkFundHome(driver);
                driver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk/");

                driver.Manage().Window.Maximize();
                Console.WriteLine("Browser is launched successfully");
            }
            catch (WebDriverException webex)
            {
                Console.WriteLine("Webdriver exception caught " + webex);
            }


        }
        [Then(@"i can select the (.*) Jurisdiction")]
        public void ThenICanSelectTheUnitedKingdomJurisdiction(string value)
        {
            fundObj.LinkActiveVerification(value);
        }
    }
}

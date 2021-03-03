using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Step_Definitions
{
    [Binding]
    //Common steps is the step definition file which binds the link feature files
    class CommonSteps
    {
        BrowserSteps browser;
        IWebDriver driver;
        PageObjectModel.LinkHome homeObj;
        PageObjectModel.LinkFundHome fundObj;
        [StepDefinition(@"I open the home page")]
        public void WhenIOpenTheHomePage()
        {
            try
            {
                browser = BrowserSteps.getBrowserInstance("chrome", null);
                driver = browser.GetDriver();
                homeObj = new PageObjectModel.LinkHome(driver);
                driver.Navigate().GoToUrl("https://www.linkgroup.eu/");
                driver.Manage().Window.Maximize();
                Console.WriteLine("Browser is launched successfully");


            }
            catch(WebDriverException webex)
            {
                Console.WriteLine("Webdriver exception caught " + webex);
            }



        }

        [When(@"i open the Fund Solutions page")]
        public void WhenIOpenTheFundSolutionsPage()
        {
            try { 
                browser = BrowserSteps.getBrowserInstance("chrome", null);
                driver = browser.GetDriver();
                fundObj = new PageObjectModel.LinkFundHome(driver);
                driver.Navigate().GoToUrl("https://www.linkfundsolutions.co.uk/");

                driver.Manage().Window.Maximize();
            Console.WriteLine("Browser is launched successfully");
        }
            catch(WebDriverException webex)
            {
                Console.WriteLine("Webdriver exception caught " + webex);
            }


}
        [Then(@"i can select the (.*) Jurisdiction")]
        public void ThenICanSelectTheUnitedKingdomJurisdiction(string value)
        {
            fundObj.LinkActiveVerification(value);
        }



        [Given(@"I have opened the home page")]
        public void GivenIHaveOpenedTheHomePage()
        {
            if (driver != null)
            {
                string ActualTitle = driver.Title;
                if (ActualTitle.Trim().Equals("Home"))
                {
                    Console.WriteLine("Home page is not opened");
                }
            }
            else
            {
                WhenIOpenTheHomePage();
            }

            

        }
     

        [Given(@"i have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            homeObj.ClickAcceptButton();

        }

        [When(@"i search for (.*)")]
        public void WhenISearchFor_(string text)
        {
          homeObj.Search(text);

        }

        [Then(@"the search results are displayed")]
        public void ThenTheSearchResultsAreDisplayed()
        {
            homeObj.SearchResultVerification("You searched for:\"Leeds\"");
        }




        [Then(@"the page is displayed")]
        public void ThenThePageIsDisplayed()
        {
            string ActualTitle = driver.Title;
            Assert.AreEqual("Home", ActualTitle, "The title is not as expected, actual value displayed is " + ActualTitle);
        }
        }

    }


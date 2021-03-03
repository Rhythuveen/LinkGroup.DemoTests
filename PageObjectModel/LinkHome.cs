using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LinkGroup.DemoTests.PageObjectModel
{
    public class LinkHome
    {
        private IWebDriver driver;
        By AcceptButton = By.XPath("//a[contains(@class,'cc-dismiss')]");
        By SearchLensButton = By.Id("navbardrop");
        By SearchBox = By.Name("searchTerm");
        By SearchButton = By.XPath("//button[contains(text(),'Search')]");
        By SearchResults = By.XPath("//*[@id='SearchResults']/h3");
       
        public LinkHome(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void SearchResultVerification(string expected)
        {
            string ActualValue = driver.GetElement(SearchResults).Text.Trim();
            string actualunescape = Regex.Replace(ActualValue, "\r\n","");

            Assert.AreEqual(expected, actualunescape, "The search results are not as expected");

        }

      
            public void ClickAcceptButton()
        {
           
            driver.GetElement(AcceptButton);
            driver.GetElement(AcceptButton).Click();
        }

        public void Search(string text)
        {
            driver.GetElement(SearchLensButton).Click();
            driver.GetElement(SearchBox).SendKeys(text);
            driver.GetElement(SearchButton).Click();
        }
        

    }
    
}

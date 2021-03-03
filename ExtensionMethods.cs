using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LinkGroup.DemoTests
{
    public static class ExtensionMethods
    {
        private static WebDriverWait Wait;

        public static IWebElement GetElement(this IWebDriver driver, By byLocator)
        {
            IWebElement foundelement = null;
            try
            {
                foundelement = driver.FindElement(byLocator);
            }
            catch (Exception e)

            {
                Console.WriteLine("Exception caught " + e);
                foundelement = Wait.Until<IWebElement>(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byLocator));

            }
            return foundelement;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace LinkGroup.DemoTests.PageObjectModel
{
    public class LinkFundHome
    {
      

        private IWebDriver driver;
        By JurisdictionList = By.XPath("//*[@class='SplashThreeImage']/ul/li/a");

        public LinkFundHome(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void LinkActiveVerification(string linkName)
        {
           IList<IWebElement> listitems = driver.FindElements(JurisdictionList);
           foreach(var item in listitems)
            {
                if(item.Text == linkName)
                {
                    if (item.Enabled)
                    {
                        try
                        {
                            var href = item.GetAttribute("href");
                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(href));
                            var response = (HttpWebResponse)req.GetResponse();
                            var status = response.StatusCode;
                            Assert.AreEqual(status.ToString(), "OK", "Response is not OK, the response code of the link " + linkName + " is " + status);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Exception caught " + e);
                        }
                    }
                }
            }
        }
    }
}

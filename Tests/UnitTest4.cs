using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            
            List<int> numOfLists = new List<int> { 2, -1, 0, 5 };
            for (int i = 0; i < numOfLists.Count; i++)
            {
                //toggling the 'lists' radio button
                lipsum.GenerateLists(numOfLists[i]);
                LipsumResultsPage result = new LipsumResultsPage();

                result.WaitToLoad();

                //IWebElement list = Driver.webDriver.FindElement(By.XPath("//div[@id='lipsum']"));
                //string listText = list.Text;
                int j = 0;
                int cnt = 2;
                //while (j <= listText.Length - 1)
                //{
                //    if (listText[j].Equals("\r\n"))
                //    {
                //        cnt++;
                //    }
                //    j++;
                //}
                Assert.AreEqual(numOfLists, cnt);
                result.driver.Navigate().Back();
                lipsum.WaitToLoad();
            }
            lipsum.driver.Quit();
        }
    }
}
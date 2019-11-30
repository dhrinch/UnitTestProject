using OpenQA.Selenium;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            
            List<int> numOfWords = new List<int> { 20, -1, 0, 15, 50 };
            for (int i = 0; i < numOfWords.Count; i++)
            {
                lipsum.GenerateWords(numOfWords[i]);
                lipsum.WaitToLoad();
                LipsumResultsPage result = new LipsumResultsPage();
                PageFactory.InitElements(result.driver, result);

                string bodyText = result.GetBodyText();

                int j = 0;
                int cnt = 1;
                while (j <= bodyText.Length - 1)
                {
                    if (bodyText[j] == ' ' || bodyText[j] == '\t')
                    {
                        cnt++;
                    }
                    j++;
                }
                Assert.AreEqual(numOfWords, cnt);
                result.driver.Navigate().Back();
                lipsum.WaitToLoad();
            }
            lipsum.driver.Quit();
        }
    }
}
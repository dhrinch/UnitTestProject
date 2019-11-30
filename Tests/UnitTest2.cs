using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            PageFactory.InitElements(lipsum.driver, lipsum);

            List<string> paragraphs = new List<string>();
            int numOfParagraphs = 5;
            int numOfRuns = 2;
            int cnt = 0;
            //string text = "";
            for (int i = 0; i < numOfRuns; i++)
            {
                lipsum.StartWithChkbox();
                lipsum.GenerateParagraphs(numOfParagraphs);
                lipsum.WaitToLoad();
                LipsumResultsPage result = new LipsumResultsPage();
                PageFactory.InitElements(result.driver, result);

                //adding all paragraphs on a page to a list
                foreach (var element in result.driver.FindElements(By.TagName("p")))
                {
                    paragraphs.Add(element.Text);
                }

                for (int j = 0; j < numOfParagraphs; j++)
                {
                    if (paragraphs[j].Contains("lorem") || paragraphs[j].Contains("Lorem"))
                    {
                        cnt++;
                    }
                }

                //for (int j = 0; j < numOfParagraphs; j++)
                //    text = result.GetParagraphText();
                //{
                //    if (text.ToLower().Contains("lorem"))
                //    {
                //        cnt++;
                //    }
                //}
                result.driver.Navigate().Back();
                paragraphs.Clear();
                lipsum.WaitToLoad();
            }
            Assert.IsTrue(cnt / numOfRuns >= 3, cnt / numOfRuns + " - less than three");
            lipsum.driver.Quit();
        }
    }
}
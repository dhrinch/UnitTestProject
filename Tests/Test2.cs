using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();

            List<string> paragraphs = new List<string>();
            int numOfParagraphs = 5;
            int numOfRuns = 2;
            int cnt = 0;
            //string text = "";
            for (int i = 0; i < numOfRuns; i++)
            {
                lipsum.StartWithChkbox();
                lipsum.GenerateLorem("paragraphs", numOfParagraphs);
                lipsum.WaitToLoad();
                LipsumResultParagraph result = new LipsumResultParagraph();

                //adding all paragraphs on a page to a list
                foreach (var element in result.driver.FindElements(By.TagName("p")))
                {
                    paragraphs.Add(element.Text.ToLower());
                }

                for (int j = 0; j < numOfParagraphs; j++)
                {
                    if (paragraphs[j].Contains("lorem"))
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
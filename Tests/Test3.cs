using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test3
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();

            List<int> numOfWords = new List<int> { 5, 20, -1, 0, 15, 50 };
            for (int i = 0; i < numOfWords.Count; i++)
            {
                lipsum.GenerateLorem("words", numOfWords[i]);
                lipsum.WaitToLoad();
                LipsumResultParagraph result = new LipsumResultParagraph();

                string bodyText = result.GetBodyText();

                int j = 0;
                int cnt = 1;
                while (j <= bodyText.Length - 1)
                {
                    if (bodyText[j] == ' ')
                    {
                        cnt++;
                    }
                    j++;
                }
                Assert.AreEqual(numOfWords[i], cnt);
                result.driver.Navigate().Back();
                lipsum.WaitToLoad();
            }
            lipsum.driver.Quit();
        }
    }
}
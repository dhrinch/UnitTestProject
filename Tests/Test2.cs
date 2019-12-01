using Microsoft.VisualStudio.TestTools.UnitTesting;
//using UnitTestProject.Pages;
using UnitTestProject.Assembly;
//using System.Collections.Generic;
//using OpenQA.Selenium;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void TestMethod1()
        {

            BLL model = new BLL();

            model.GoToLipsum();

            int numOfRuns = 2;
            int numOfResultItems = 5;
            string word = "lipsum";
            int counter = 0;
            for (int i = 0; i < numOfRuns; i++)
            {
                model.GenerateLorem("paragraphs", numOfResultItems);
                counter = model.CountWordInParagraphs(word);
                //Result result = new Result();

                //List<IWebElement> paragraphs = result.GetParagraphsList();
                //foreach (IWebElement element in paragraphs)
                //{
                //    if (element.Text.ToLower().Contains("lorem"))
                //    {
                //        counter++;
                //    }
                //}
                Driver.Back();
            }
            ///Driver.Quit();
            Assert.IsTrue(counter / numOfRuns >= 3, counter / numOfRuns + " - less than three");
        }
    }
}
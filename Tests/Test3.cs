using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Pages;
using UnitTestProject.Assembly;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test3
    {
        [TestMethod]
        public void TestMethod1()
        {
            BLL model = new BLL();

            model.GoToLipsum();
            //int counter = 0;

            List<int> howManyWords = new List<int> { 5, 20, -1, 0, 15, 50 };
            for (int i = 0; i < howManyWords.Count; i++)
            {
                model.GenerateLorem("words", howManyWords[i]);
                //Result result = new Result();

                //string[] bodyText = result.GetAllParagraphs();
                //int size = result.GetAllParagraphs().Length;
                //for (int j = 0; j <= size; j++)
                //{
                    //if (bodyText[j].Equals(' '))
                    //{
                        //counter++;
                    //}
                //}
                //Assert.AreEqual(howManyWords[i], counter);
                Assert.AreEqual(howManyWords[i], model.CountResultingWords());
                Driver.Back();
            }
            Driver.Quit();
        }
    }
}
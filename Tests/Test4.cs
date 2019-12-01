using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test4
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            
            List<int> numOfLists = new List<int> { 2, -1, 0, 5 };
            for (int i = 0; i < numOfLists.Count; i++)
            {
                lipsum.GenerateLorem("lists", numOfLists[i]);
                LipsumResultList result = new LipsumResultList();

                result.WaitToLoad();

                //Assert.AreEqual(numOfLists, cnt);
                result.driver.Navigate().Back();
                lipsum.WaitToLoad();
            }
            lipsum.driver.Quit();
        }
    }
}
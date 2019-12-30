using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
<<<<<<< HEAD
using UnitTestProject.Assembly;
=======
>>>>>>> origin/master
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test4
    {
        [TestMethod]
        public void TestMethod1()
        {
<<<<<<< HEAD
            List<int> howManyLists = new List<int> { 2, -1, 0, 5 };
            BLL model = new BLL();

            model.GoToLipsum();

            for (int i = 0; i < howManyLists.Count; i++)
            {
                model.GenerateLorem("lists", howManyLists[i]);

                ResultList result = new ResultList();

                //Assert.AreEqual(numOfLists, cnt);
                Driver.Back();
            }
            Driver.Quit();
=======
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
>>>>>>> origin/master
        }
    }
}
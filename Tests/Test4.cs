using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject.Assembly;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test4
    {
        [TestMethod]
        public void TestMethod1()
        {
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
        }
    }
}
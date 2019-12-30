using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            lipsum.ChangeLanguage();

            LipsumLandingRu lipsumRu = new LipsumLandingRu();

            Assert.IsTrue(lipsumRu.GetParagraphText().Contains("рыба"), "Doesn't contain 'рыба'");
            lipsum.driver.Quit();           
        }        
    }
}

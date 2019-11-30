using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LipsumLandingPage lipsum = new LipsumLandingPage();
            PageFactory.InitElements(lipsum.driver, lipsum);
            lipsum.ChangeLanguage();

            LipsumLandingRu lipsumRu = new LipsumLandingRu();
            PageFactory.InitElements(lipsumRu.driver, lipsumRu);

            Assert.IsTrue(lipsumRu.GetParagraphText().Contains("рыба"), "Doesn't contain 'рыба'");
            lipsum.driver.Quit();           
        }        
    }
}

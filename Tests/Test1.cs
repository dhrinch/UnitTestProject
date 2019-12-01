using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Assembly;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BLL model = new BLL();

            model.GoToLipsum();
            model.ChangePageLanguage("russian");

            string word = "рыба";
            bool isWordPresent = model.IsWordOnTranslatedPage(word);
            //Driver.Quit();           
            Assert.IsTrue(isWordPresent, $"Doesn't contain {word}");
        }        
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    class ResultList
    {
        private readonly IWebDriver driver;

        //[FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        //private IWebElement body { set; get; }

        [FindsBy(How = How.XPath, Using = "$//ul[n]")]
        private IWebElement list { set; get; }

        //public string GetBodyText()
        //{
        //    return body.Text;
        //}

        public string GetList(int N)
        {
            int n = N;
            return driver.FindElement(By.XPath($"//ul[n]")).Text;
        }

        public ResultList()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            //body = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            list = driver.FindElement(By.XPath($"//ul[n]"));
        }
    }
}

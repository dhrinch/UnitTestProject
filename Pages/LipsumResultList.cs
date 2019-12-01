using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    class LipsumResultList
    {
        public IWebDriver driver;

        //[FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        //private IWebElement body { set; get; }

        [FindsBy(How = How.XPath, Using = "$//ul[n]")]
        private IWebElement list { set; get; }

        //public string GetBodyText()
        //{
        //    return body.Text;
        //}

        public string GetList(int n)
        {
            return driver.FindElement(By.XPath($"//ul[n]")).Text;
        }

        public void WaitToLoad()
        {
            System.Threading.Thread.Sleep(3000);
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(500));
            //WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            //waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Lorem Ipsum')]")));
        }

        public LipsumResultList()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            //body = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            list = driver.FindElement(By.XPath($"//ul[n]"));
            WaitToLoad();
        }
    }
}

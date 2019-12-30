using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    public class LipsumResultParagraph
    {
        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        private IWebElement body { set; get; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),")]
        private IWebElement paragraph { set; get; }

        [FindsBy(How = How.XPath, Using = "$//ul[n]")]
        private IWebElement list { set; get; }

        public string GetBodyText()
        {
            return body.Text;
        }

        public string GetParagraphText()
        {
            return paragraph.Text;
        }

        public void WaitToLoad()
        {
            System.Threading.Thread.Sleep(3000);
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(500));
            //WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            //waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Lorem Ipsum')]")));
        }

        public LipsumResultParagraph()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            //paragraph = driver.FindElement(By.XPath("//p[contains(text(),'']"));
            body = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            WaitToLoad();
        }
    }
}

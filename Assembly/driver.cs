using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UnitTestProject.Assembly
{
    public class Driver
    {
        private static IWebDriver driver;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new EdgeDriver();
            }
            return driver;
        }

        public static void GoToPage(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        
        public static void Quit()
        {
            driver.Quit();
        }

        public static void Back()
        {
            driver.Navigate().Back();
        }

        public static void Wait(int nSeconds = 30)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(nSeconds);
            //System.Threading.Thread.Sleep(3000);
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(500));
            //WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='generate']")));
        }
    }
}

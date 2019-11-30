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

        public static void Quit()
        {
            driver.Quit();
        }

        public static void Back()
        {
            driver.Navigate().Back();
        }
    }
}

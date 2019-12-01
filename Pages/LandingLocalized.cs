using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    public class LandingLocalized
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//p[contains(.,'')]")]
        public IWebElement paragraph { get; set; }

        public string GetParagraphText()
        {
            string paragraphText = paragraph.Text;
            return paragraphText;
        }

        public LandingLocalized()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            paragraph = driver.FindElement(By.XPath("//p[contains(.,'')]"));
        }
    }
}

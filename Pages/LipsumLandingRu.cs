using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    public class LipsumLandingRu
    {
        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='start']")] //"Start with..." checkbox
        private IWebElement startWithChkbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='paras']")] //"Paragraphs" radio button
        private IWebElement paragraphsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='words']")] //"Words" radio button
        private IWebElement wordsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='lists']")] //"Lists" radio button
        private IWebElement listsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'amount')]")] //number to generate textbox
        public IWebElement nmbrToGenerate { get; set; }

        [FindsBy(How = How.XPath, Using = "input[contains(@id,'generate')]")] //"Generate..." button
        public IWebElement generateBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p")]
        public IWebElement paragraph { get; set; }

        //Toggling the 'Start with 'Lorem ipsum...'' checkbox
        public void StartWithChkbox()
        {
            startWithChkbox.Click();
        }

        //Generate n paragraphs of loremipsum
        public void SetValue(string radioLabel, int n)
        {
            if (radioLabel.Equals("words")) wordsRadio.Click();
            if (radioLabel.Equals("paragraphs")) paragraphsRadio.Click();
            if (radioLabel.Equals("lists")) listsRadio.Click();
            nmbrToGenerate.Clear();
            nmbrToGenerate.SendKeys("" + n);
            generateBtn.Click();
        }

        public string GetParagraphText()
        {
            IWebElement paragraph = driver.FindElement(By.XPath("//p"));
            string paragraphText = paragraph.Text;
            return paragraphText;
        }
        public void WaitToLoad()
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='generate']")));
        }

        public LipsumLandingRu()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            paragraph = driver.FindElement(By.XPath("//p"));
            startWithChkbox = driver.FindElement(By.XPath("//*[@id='start']")); //"Start with..." checkbox
            paragraphsRadio = driver.FindElement(By.XPath("//*[@id='paras']"));//"Paragraphs" radio button
            wordsRadio = driver.FindElement(By.XPath("//*[@id='words']"));//"Words" radio button
            listsRadio = driver.FindElement(By.XPath("//*[@id='lists']"));//"Lists" radio button
            nmbrToGenerate = driver.FindElement(By.XPath("//input[@id='amount']")); //number to generate textbox
            generateBtn = driver.FindElement(By.XPath("//input[@id='generate']")); //"Generate..." button
            WaitToLoad();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    public class LandingPage
    {
        public IWebDriver driver;

        private string url = "https://lipsum.com/";

        [FindsBy(How = How.XPath, Using = "//a[@class='ru']")] //Russian language page
        private IWebElement russian { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='paras']")] //"Paragraphs" radio button
        private IWebElement paragraphsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='words']")] //"Words" radio button
        private IWebElement wordsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lists']")] //"Lists" radio button
        private IWebElement listsRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")] //number to generate textbox
        public IWebElement nmbrToGenerate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")] //"Generate..." button
        public IWebElement generateBtn { get; set; }

        //Switching to another language page
        public void SetRusLang()
        {
            russian.Click();
        }

        //Selecting type of 'Lorem ipsum...' objects to generate
        public void SelectType2Generate(string radioLabel) 
        {
            if (radioLabel.ToLower().Equals("words")) wordsRadio.Click();
            if (radioLabel.ToLower().Equals("paragraphs")) paragraphsRadio.Click();
            if (radioLabel.ToLower().Equals("lists")) listsRadio.Click();           
        }

        //Defining how many 'Lorem ipsum...' objects to generate
        public void SetNum2Generate(int number)
        {
            nmbrToGenerate.Clear();
            nmbrToGenerate.SendKeys("" + number);
        }

        public void GenerateClick()
        {
            generateBtn.Click();
        }
        
        public LandingPage()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            russian = driver.FindElement(By.XPath("//a[@class='ru']"));//Russian language page
            paragraphsRadio = driver.FindElement(By.XPath("//input[@id='paras']"));//"Paragraphs" radio button
            wordsRadio = driver.FindElement(By.XPath("//input[@id='words']"));//"Words" radio button
            listsRadio = driver.FindElement(By.XPath("//input[@id='lists']"));//"Lists" radio button
            nmbrToGenerate = driver.FindElement(By.XPath("//input[@id='amount']")); //number to generate textbox
            generateBtn = driver.FindElement(By.XPath("//input[@id='generate']")); //"Generate..." button
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;

namespace UnitTestProject.Pages
{
    public class LipsumLandingPage
    {
        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='ru']")] //Russian language page
        private IWebElement russian { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@id='start']")] //"Start with..." checkbox
        private IWebElement startWithChkbox { get; set; }
        
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
        public void ChangeLanguage() 
        {
            russian.Click();
            WaitToLoad();
        }

        //Toggling the 'Start with 'Lorem ipsum...'' checkbox
        public void StartWithChkbox()
        {
            startWithChkbox.Click();
        }
        //Generating 'Lorem ipsum...' of required type
        public void GenerateLorem(string radioLabel, int n) 
        {
            if (radioLabel.Equals("words")) wordsRadio.Click();
            if (radioLabel.Equals("paragraphs")) paragraphsRadio.Click();
            if (radioLabel.Equals("lists")) listsRadio.Click();
            nmbrToGenerate.Clear();
            nmbrToGenerate.SendKeys("" + n);
            generateBtn.Click();
        }

        public void WaitToLoad()
        {
            System.Threading.Thread.Sleep(5000);
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(500));
            //WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='generate']")));
        }

        public LipsumLandingPage()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl("https://lipsum.com/");
            russian = driver.FindElement(By.XPath("//a[@class='ru']"));//Russian language page
            startWithChkbox = driver.FindElement(By.XPath("//input[@id='start']")); //"Start with..." checkbox
            paragraphsRadio = driver.FindElement(By.XPath("//input[@id='paras']"));//"Paragraphs" radio button
            wordsRadio = driver.FindElement(By.XPath("//input[@id='words']"));//"Words" radio button
            listsRadio = driver.FindElement(By.XPath("//input[@id='lists']"));//"Lists" radio button
            nmbrToGenerate = driver.FindElement(By.XPath("//input[@id='amount']")); //number to generate textbox
            generateBtn = driver.FindElement(By.XPath("//input[@id='generate']")); //"Generate..." button
            WaitToLoad();
        }
    }
}

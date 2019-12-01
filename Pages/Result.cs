using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Assembly;
using System;
using System.Collections.Generic;

namespace UnitTestProject.Pages
{
    public class Result
    {
        public IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        private IWebElement body { set; get; }

        //[FindsBy(How = How.XPath, Using = "//p[contains(text(),")]
        //private IWebElement paragraph { set; get; }

        [FindsBy(How = How.TagName, Using = "p")]
        private IList<IWebElement> allParagraphs { set; get; }

        //public string GetBodyText()
        //{
        //    return body.Text;
        //}

        //public string GetParagraphText()
        //{
        //    return paragraph.Text;
        //}

        public List<IWebElement> GetParagraphsList()
          {
            List<IWebElement> paragraphs = new List<IWebElement>();
            foreach(IWebElement element in allParagraphs)
            {
                paragraphs.Add(element);
            }
            return paragraphs;
        }

        public string[] GetAllParagraphs()
        {
            String[] allText = new String[allParagraphs.Count];
            int i = 0;
            foreach (IWebElement element in allParagraphs)
            {
                allText[i++] = element.Text;
            }
            return allText;
        }
        public Result()
        {
            driver = Driver.GetInstance();
            PageFactory.InitElements(driver, this);
            //paragraph = driver.FindElement(By.XPath("//p[contains(text(),'']"));
            //body = driver.FindElement(By.XPath("//div[@id='lipsum']"));
            //allParagraphs = driver.FindElements(By.XPath("//div[@id='lipsum']"));
            allParagraphs = driver.FindElements(By.TagName("p"));
        }
    }
}

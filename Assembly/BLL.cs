using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Pages;
using OpenQA.Selenium;

namespace UnitTestProject.Assembly
{
    public class BLL
    {
        private LandingPage lipsum;
        private LandingLocalized lipsumLocal;
        private Result result;
        
        public void GoToLipsum(string URL = "https://lipsum.com/")
        {
            Driver.GetInstance();
            Driver.GoToPage(URL);
            Driver.Wait();
            lipsum = new LandingPage();
        }

        public void ChangePageLanguage(string language)
        {
            if (language.ToLower().Equals("russian"))
            {
                lipsum.SetRusLang();
                Driver.Wait();
                lipsumLocal = new LandingLocalized();
            }
        } 

        public bool IsWordOnTranslatedPage(string word)
        {
            string paragraph = lipsumLocal.GetParagraphText();
            if (paragraph.Contains(word))
            {
                return true;
            }
            return false;
        }

        public void GenerateLorem(string radioLabel, int howMany)
        {
            lipsum = new LandingPage();
            lipsum.SelectType2Generate(radioLabel);
            lipsum.SetNum2Generate(howMany);
            lipsum.GenerateClick();
            Driver.Wait();
            result = new Result();
        }

        public int CountWordInParagraphs(string word)
        {
            int counter = 0;
            List<IWebElement> paragraphs = result.GetParagraphsList();
            foreach (IWebElement element in paragraphs)
            {
                if (element.Text.ToLower().Contains(word))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int CountResultingWords()
        {
            string[] bodyText = result.GetAllParagraphs();
            int size = result.GetAllParagraphs().Length;
            int counter = 0;
            for (int j = 0; j <= size; j++)
            {
                if (bodyText[j].Equals(' '))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

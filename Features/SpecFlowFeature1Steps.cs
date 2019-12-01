using System;
using TechTalk.SpecFlow;
using UnitTestProject.Tests;
using UnitTestProject.Assembly;
using UnitTestProject.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        //private LandingPage lipsum;
        //private LandingLocalized lipsumRu;
        BLL model = new BLL();

        [When(@"I navigate to Lorem Ipsum")]
        public void WhenINavigateToPage()
        {
            model.GoToLipsum();
        }
        
        [When(@"switch the page language to Russian")]
        public void WhenSwitchThePageLanguageToRussian()
        {
            model.ChangePageLanguage("russian");
        }
        
        private string word = "рыба";
        [Then(@"assert that there is the word '(.*)' in the first paragraph")]
        public void ThenAssertThatThereIsTheWordInTheFirstParagraph()
        {
            Assert.IsTrue(model.IsWordOnTranslatedPage(word), $"Doesn't contain {word}");
        }
    }
}

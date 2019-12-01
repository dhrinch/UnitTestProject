using System;
using TechTalk.SpecFlow;
using UnitTestProject.Tests;
using UnitTestProject.Assembly;
using UnitTestProject.Pages;

namespace UnitTestProject
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private LipsumLandingPage lipsum = new LipsumLandingPage();
        private LipsumLandingRu lipsumRu = new LipsumLandingRu();
        [When(@"I navigate to lipsum\.com")]
        public void WhenINavigateToLipsum_Com()
        {
        }
        
        [When(@"switch the page language to Russian")]
        public void WhenSwitchThePageLanguageToRussian()
        {
            lipsum.ChangeLanguage();
        }
        
        [Then(@"assert that there is the word '(.*)' in the first paragraph")]
        public void ThenAssertThatThereIsTheWordInTheFirstParagraph(string word)
        {
            //Assert.IsTrue(lipsumRu.GetParagraphText().Contains("рыба"), "Doesn't contain 'рыба'");
        }
    }
}

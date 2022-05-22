using System;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject3.PageObjects;
using TestProject3.Tests;

namespace TestProject3
{
    [Binding]
    public class Task4StepDefinitions : BaseTest
    {
        readonly String test_url = "https://lipsum.com/";
        private static long DEFAULT_TIMEOUT = 15;

        [Before]
        public void Before()
        {
            getDriver().Url = test_url;
            getDriver().Manage().Window.Maximize();
        }

        [After]
        public void After()
        {
            getDriver().Close();
        }

        [Given(@"\[User is at the Home Page]")]
        public void GivenUserIsAtTheHomePage()
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetRussianLanguege());
        }

        [When(@"\[Change language to Russian]")]
        public void WhenChangeLanguageToRussian()
        {
            getHomePage().ChangeLanguageToRussian();
        }

        [Then(@"\[Check (.*) in first paragraph]")]
        public void ThenCheckWordInFirstParagraph(String word)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetFirstParagraph());
            getHomePage().CheckFirstParagraph(word);
        }

        [When(@"\[Generate new text]")]
        public void WhenGenerateNewText()
        {
            getHomePage().ClickGenerate();
            getHomePage().WaitLittell(DEFAULT_TIMEOUT);
        }

        [Then(@"\[Check text starting with ""(.*)""]")]
        public void ThenCheckTextStartingWith(String Lorem)
        {
            getGeneretedPage().CheckTextStartingWithLoremIpsumh(Lorem);
        }

        [When(@"\[Set button ""([^""]*)""]")]
        public void WhenSetButton(string words)
        {
            getRadioButton().SetValue(words);
        }

        [When(@"\[Enter amount (.*)]")]
        public void WhenEnterAmount(int number)
        {
            getHomePage().EnterAmount(number);
        }

        [Then(@"\[Check amount of words (.*)]")]
        public void ThenCheckAmountOfWords(int number)
        {
            getGeneretedPage().CheckAmountOfWords(number);
        }

        [Then(@"\[Check amount of characters (.*)]")]
        public void ThenCheckAmountOfCharacters(int number)
        {
            getGeneretedPage().CheckAmountOfCharacters(number);
        }

        [When(@"\[Selects an option without LoremIpsum]")]
        public void WhenSelectsAnOptionWithoutLoremIpsum()
        {
            getHomePage().ClickCheckBox();
        }

        [Then(@"\[Check text without ""([^""]*)""]")]
        public void ThenCheckTextWithout(string LoremIpsum)
        {
            getGeneretedPage().CheckWithoutLorem(LoremIpsum);
        }

        [Then(@"\[Check probability of word ""([^""]*)""]")]
        public void ThenCheckProbabilityOfWord(string lorem)
        {
            getHomePage().CheckProbabilityOfMoreThan40(lorem);
        }

    }
}

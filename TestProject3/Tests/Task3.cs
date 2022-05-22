using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using TestProject3.PageObjects;

namespace TestProject3.Tests
{

    [TestClass]
    public class Part3 : BaseTest
    {
         private static long DEFAULT_TIMEOUT = 15;

        [TestMethod]
        [DataRow("рыба")]
        public void WordCorrectlyAppearsInTheFirstParagraph(string word)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetRussianLanguege());
            getHomePage().ChangeLanguageToRussian();
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetFirstParagraph());
            getHomePage().CheckFirstParagraph(word); 
        }

        [TestMethod]
        [DataRow("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void TextStartingWithLoremIpsum(string Lorem)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetGenerateButton());
            getHomePage().ClickGenerate();
            getHomePage().WaitLittell(DEFAULT_TIMEOUT);
            getGeneretedPage().CheckTextStartingWithLoremIpsumh(Lorem);
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(20)]
        public void GeneratedWithCorrectSizeWords(int number)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetGenerateButton());
            getRadioButton().SetValue("words");
            getHomePage().EnterAmount(number);
            getHomePage().ClickGenerate();
            getHomePage().WaitLittell(DEFAULT_TIMEOUT);
            getGeneretedPage().CheckAmountOfWords(number);
        }
      
        [TestMethod]
        [DataRow(60)]
        [DataRow(30)]
        [DataRow(0)]
        public void GeneratedWithCorrectSizeCharacters(int number)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetGenerateButton());
            getRadioButton().SetValue("bytes");
            getHomePage().EnterAmount(number);
            getHomePage().ClickGenerate();
            getHomePage().WaitLittell(DEFAULT_TIMEOUT);
            getGeneretedPage().CheckAmountOfCharacters(number);
        }
        [TestMethod]
        [DataRow("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void VerifyCheckbox(string LoremIpsum)
        {
            getHomePage().WaitClickabilityOfElement(DEFAULT_TIMEOUT, getHomePage().GetStartButton());
            getHomePage().ClickCheckBox();
            getHomePage().ClickGenerate();
            getHomePage().WaitLittell(DEFAULT_TIMEOUT);
            getGeneretedPage().CheckWithoutLorem(LoremIpsum);
        }
        [TestMethod]
        [DataRow("lorem")]
        public void ProbabilityOfMoreThan40(string Lorem)
        {
            getHomePage().CheckProbabilityOfMoreThan40(Lorem);
        }
    }
}
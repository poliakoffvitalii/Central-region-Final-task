using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;




namespace TestProject3.PageObjects
{
    public class GeneretedPage : BasePage

    {
        public GeneretedPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']")]
        private IWebElement generatedParagraph;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        private IWebElement generatedText;



        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void CheckTextStartingWithLoremIpsumh(string Lorem)
        {
            Assert.IsTrue(generatedParagraph.Text.StartsWith(Lorem));
        }

        public void CheckAmountOfWords(int number)
        {
            int expected;
            if (number < 1)
            {
                expected = 5;
            }
            else
            {
                expected = number;
            }
            string[] separatingStrings = { " ", ",", ".", ":", "\t", ", ", ". ", "! ", "? " };
            Assert.AreEqual(expected, generatedText.Text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries).Length);
        }

        public void CheckAmountOfCharacters(int number)
        {
            int expected;
            if (number < 1)
            {
                expected = 5;
            }
            else
            {
                expected = number;
            }
            Assert.AreEqual(expected, generatedText.Text.Length);
        }

        public void CheckWithoutLorem(string Lorem)
        {
            Assert.IsFalse(generatedText.Text.StartsWith(Lorem));
        }
        public decimal CountLorem(string Lorem, decimal countB)
        {
            foreach (IWebElement element in getHomePage().GetGeneratedTextList())
            {
                if (element.Text.ToLower().Contains(Lorem))
                {
                    countB++;
                }
            }
            return countB;
        }


        public HomePage getHomePage()
        {
            return new HomePage(GetDriver());
        }
    }
}


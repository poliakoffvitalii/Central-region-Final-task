using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject3.Tests
{
    [TestClass]

    public class Part1
    {
        readonly string TEST_URL = "https://lipsum.com/";

        [TestMethod]
        [DataRow("рыба")]
        public void WordCorrectlyAppearsInTheFirstParagraph(string word)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl(TEST_URL);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='Languages']/a[contains(@href, 'ru.')]")));

            driver.FindElement(By.XPath("//div[@id='Languages']/a[contains(@href, 'ru.')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='Panes']/div[1]")));

            WebElement element = (WebElement)driver.FindElement(By.XPath("//div[@id='Panes']/div[1]/p"));
            Assert.IsTrue(element.Text.Contains(word));

            driver.Close();
        }
        [TestMethod]
        [DataRow("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void TextStartingWithLoremIpsum(string Lorem)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl(TEST_URL);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='generate']")));

            driver.FindElement(By.XPath("//input[@id='generate']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='lipsum']")));

            WebElement element = (WebElement)driver.FindElement(By.XPath("//div[@id='lipsum']/p"));
            Assert.IsTrue(element.Text.StartsWith(Lorem));

            driver.Close();
        }
    }
    [TestClass]
    public class Part2
    {
        readonly string TEST_URL = "https://lipsum.com/";
        readonly int[] NUMBER_OF_WORDS = { 10, -1, 0, 5, 20 };
        readonly int[] NUMBER_OF_CHARACTERS = { 60, -1, 0 };
        int expected;

        [TestMethod]
        [DataRow(10)]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(5)]
        [DataRow(20)]
        public void GeneratedWithCorrectSizeWords(int number)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl(TEST_URL);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@for='words']")));
            driver.FindElement(By.XPath("//label[@for='words']")).Click();

            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys(number.ToString());
            driver.FindElement(By.XPath("//input[@id='generate']")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='lipsum']")));

            IWebElement element = (IWebElement)driver.FindElement(By.XPath("//div[@id='lipsum']/p"));

            if (number < 1)
            {
                expected = 5;
            }
            else
            {
                expected = number;
            }
            string[] separatingStrings = { " ", ",", ".", ":", "\t", ", ", ". ", "! ", "? " };
            int fact =  element.Text.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(expected, fact);
            driver.Close();
        }

        [TestMethod]
        [DataRow(60)]
        [DataRow(30)]
        [DataRow(0)]
        public void GeneratedWithCorrectSizeCharacters(int number)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl(TEST_URL);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@for='bytes']")));
            driver.FindElement(By.XPath("//label[@for='bytes']")).Click();

            driver.FindElement(By.XPath("//input[@id='amount']")).Clear();
            driver.FindElement(By.XPath("//input[@id='amount']")).SendKeys(number.ToString());
            driver.FindElement(By.XPath("//input[@id='generate']")).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='lipsum']")));

            WebElement element = (WebElement)driver.FindElement(By.XPath("//div[@id='lipsum']/p"));

            if (number < 1)
            {
                expected = 5;
            }
            else
            {
                expected = number;
            }
            Assert.AreEqual(expected, element.Text.Length);
            driver.Close();
        }

        [TestMethod]
        [DataRow("Lorem ipsum dolor sit amet, consectetur adipiscing elit")]
        public void VerifyCheckbox(string LoremIpsum)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl(TEST_URL);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='start']")));

            driver.FindElement(By.XPath("//input[@id='start']")).Click();
            driver.FindElement(By.XPath("//input[@id='generate']")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='lipsum']")));

            WebElement element = (WebElement)driver.FindElement(By.XPath("//div[@id='lipsum']/p"));
            Assert.IsFalse(element.Text.StartsWith(LoremIpsum));

            driver.Close();
        }
        [TestMethod]
        [DataRow("lorem")]
        public void ProbabilityOfMoreThan40(string Lorem)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            decimal count = 0;

            driver.Navigate().GoToUrl(TEST_URL);
            for (int i = 1; i < 11; i++)
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='generate']")));

                driver.FindElement(By.XPath("//input[@id='generate']")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='lipsum']")));

                IList<IWebElement> selectElements = driver.FindElements(By.XPath("//div[@id='lipsum']/p"));
                foreach (IWebElement element in selectElements)
                {
                    if (element.Text.ToLower().Contains(Lorem))
                    {
                        count++;
                    }
                }

                driver.Navigate().Back();
            }
            decimal average = count / 10;
            Assert.IsTrue(average >= 2);

            driver.Close();
        }
    }
}
    

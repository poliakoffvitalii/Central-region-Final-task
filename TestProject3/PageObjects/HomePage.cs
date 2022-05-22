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
    public class HomePage : BasePage
    {
        private static long DEFAULT_TIMEOUT = 5;
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='Languages']/a[contains(@href, 'ru.')]")]
        private readonly IWebElement russianLanguege;

        [FindsBy(How = How.XPath, Using = "//div[@id='Panes']/div[1]")]
        private readonly IWebElement firstParagraph;

        [FindsBy(How = How.XPath, Using = "//div[@id='Panes']/div[1]/p")]
        private readonly IWebElement textFirstParagraph;

        [FindsBy(How = How.XPath, Using = "//input[@id='generate']")]
        private readonly IWebElement generateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private readonly IWebElement fieldAmount;

        [FindsBy(How = How.XPath, Using = "//input[@id='start']")]
        private readonly IWebElement startButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='lipsum']/p")]
        private IList<IWebElement> generatedTextList;



        public IWebElement GetRussianLanguege()
        {
            return russianLanguege;
        }
        public IWebElement GetFirstParagraph()
        {
            return firstParagraph;
        }
        public IWebElement GetGenerateButton()
        {
            return generateButton;
        }
        public IWebElement GetStartButton()
        {
            return startButton;
        }

        public IList<IWebElement> GetGeneratedTextList()
        {
            return generatedTextList;
        }

        public void ChangeLanguageToRussian()
        {
            russianLanguege.Click();
        }

        public void CheckFirstParagraph(string word)
        {
            Assert.IsTrue(textFirstParagraph.Text.Contains(word));
        }

        public void ClickGenerate()
        {
            generateButton.Click();
        }

        public void EnterAmount(int amount)
        {
            fieldAmount.Clear();
            fieldAmount.SendKeys(amount.ToString());
        }


        public void ClickCheckBox()
        {
            startButton.Click();
        }

        public void CloseDriver()
        {
            driver.Close();
        }

        public void CheckProbabilityOfMoreThan40(string Lorem)
        {
            decimal count = 0;
            for (int i = 1; i < 11; i++)
            {
                ClickGenerate();
                WaitLittell(DEFAULT_TIMEOUT);
                foreach (IWebElement element in generatedTextList)
                {
                    if (element.Text.ToLower().Contains(Lorem))
                    {
                        count++;
                    }
                }
                driver.Navigate().Back();
                WaitLittell(DEFAULT_TIMEOUT);
            }
            Assert.IsTrue(count / 10 >= 2);
        }
    }
    public class RadioButton : BasePage
    {
        public RadioButton(IWebDriver driver) : base(driver)
        {
        }
        [FindsBy(How = How.XPath, Using = "//div[@id='Panes']/div[4]/form/table/tbody/tr[1]/td[2]/table/tbody/tr")]
        public IList<IWebElement> radioButtonList;

        public void SetValue(string value)
        {
            foreach (IWebElement element in radioButtonList)
            {
                if (element.Text.Contains(value))
                {
                    element.Click();
                }
            }
        }
    }
 
}



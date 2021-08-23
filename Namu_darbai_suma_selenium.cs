using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Namu_darbai_suma_selenium
{
    public class Namu_darbai_suma_selenium
    {
        static IWebDriver chrome = new ChromeDriver();


        [OneTimeSetUp]
        public static void TestSingleInputField()
        {
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";


            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }


        [Test]
        public static void uzduotis2plus2()
        {
            IWebElement inputFielda = chrome.FindElement(By.Id("sum1"));
            inputFielda.SendKeys("2");

            IWebElement inputFieldb = chrome.FindElement(By.Id("sum2"));
            inputFieldb.SendKeys("2");

            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();

            IWebElement resultElement = chrome.FindElement(By.Id("displayvalue"));


            inputFielda.Clear();
            inputFieldb.Clear();

            Assert.AreEqual("4", resultElement.Text, "Sum operation is wrong");
        }


        [Test]
        public static void uzduotisMinus5plus3()
        {
            IWebElement inputFielda2 = chrome.FindElement(By.Id("sum1"));
            inputFielda2.SendKeys("-5");

            IWebElement inputFieldb2 = chrome.FindElement(By.Id("sum2"));
            inputFieldb2.SendKeys("3");

            IWebElement button2 = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button2.Click();

            IWebElement resultElement2 = chrome.FindElement(By.Id("displayvalue"));

            inputFielda2.Clear();
            inputFieldb2.Clear();

            Assert.AreEqual("-2", resultElement2.Text, "Sum operation is wrong");

            
        }

        [Test]
        public static void uzduotisAplusB()
        {
            IWebElement inputFielda3 = chrome.FindElement(By.Id("sum1"));
            inputFielda3.SendKeys("a");

            IWebElement inputFieldb3 = chrome.FindElement(By.Id("sum2"));
            inputFieldb3.SendKeys("b");

            IWebElement button3 = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button3.Click();

            IWebElement resultElement3 = chrome.FindElement(By.Id("displayvalue"));

            inputFielda3.Clear();
            inputFieldb3.Clear();

            Assert.AreEqual("NaN", resultElement3.Text, "Has to be NaN");
        }

        [OneTimeTearDown]
        public static void Quit()
        {
            chrome.Quit();
        }

     }
}


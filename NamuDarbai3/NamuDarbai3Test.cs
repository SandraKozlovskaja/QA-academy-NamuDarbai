using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestPageTemplate.Page;

namespace TestPageTemplate.Test
{
    public class NamuDarbai3Test
    {
        private static NamuDarbai3Page page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new NamuDarbai3Page(chrome);
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("2", "2", "4", TestName = "2 plus 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plus b = NaN")]

        public static void TestSum(string firstInput, string secondInput, string expectedResult)
        {
            page.NavigateToPage();
            page.ClearAndInputFirstField(firstInput);
            page.ClearAndInputSecondField(secondInput);
            page.ClickGetTotal();
            page.VerifyResult(expectedResult);
        }
    }
}

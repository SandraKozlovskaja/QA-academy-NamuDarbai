using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestPageTemplate.Page
{
    public class NamuDarbai3Page : BasePage
    {
        private const string AddressUrl = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
        private IWebElement firstInputField => Driver.FindElement(By.Id("sum1"));
        private IWebElement secondInputField => Driver.FindElement(By.Id("sum2"));
        private IWebElement GetTotalButton => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement actualResult => Driver.FindElement(By.Id("displayvalue"));
        public NamuDarbai3Page(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }


        public void ClearAndInputFirstField(string firstInput)
        {
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);
        }
        public void ClearAndInputSecondField(string secondInput)
        {
            secondInputField.Clear();
            secondInputField.SendKeys(secondInput);
        }

        public void ClickGetTotal()
        {
            GetTotalButton.Click();
        }

        public void VerifyResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, actualResult.Text, $"Actual result differs from expected");
        }

    }

}


using System.Linq;
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestPageTemplate.Page
{
    public class NamuDarbai4Page : BasePage
    {
        private const string AddressUrl = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";
        private SelectElement dropdown => new SelectElement(Driver.FindElement(By.Id("cars")));
        private IWebElement resultElement => Driver.FindElement(By.CssSelector("body > div.w3-container.w3-large.w3-border"));
        private IWebElement submitButton => Driver.FindElement(By.CssSelector("body > form > input[type=submit]"));
        private IWebElement runButton => Driver.FindElement(By.CssSelector("#runbtn"));

        private IWebElement acceptPrivacyPolicyButton => Driver.FindElement(By.Id("accept-choices"));

        public NamuDarbai4Page(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }

        public void AcceptCookies()
        {
            try
            {
                acceptPrivacyPolicyButton.Click();
            }
            catch (NoSuchElementException)
            {
                //do nothing, there is no cookies window
            }
        }

        public void SelectCarModelFromDropdown(string[] CarModelsArray)
        {
            var CarModels = CarModelsArray.ToList();
            Driver.SwitchTo().Frame("iframeResult");
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (IWebElement selectCarModel in dropdown.Options)
            {
                if (CarModels.Contains(selectCarModel.Text))
                {
                    dropdown.SelectByText(selectCarModel.Text);
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }

        public void ClickSubmitButton()
        {
            submitButton.Click();
        }

        public void VerifyResult(string[] SelectedCarModels)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            Driver.SwitchTo().Frame("iframeResult");

            foreach (string selectedCar in SelectedCarModels)
            {
                Assert.IsTrue(resultElement.Text.Contains(selectedCar), "Selected option is : " + selectedCar,
                resultElement.Text, "Selected car is wrong");
            }
        }


        public void RefreshWebPage()
        {
            Driver.SwitchTo().DefaultContent();
            runButton.Click();
        }
    }
}

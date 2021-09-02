using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestPageTemplate.Page;

namespace TestPageTemplate.Test
{
    public class NamuDarbai4Test
    {
        private static NamuDarbai4Page page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new NamuDarbai4Page(chrome);
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase(new string[] { "Volvo" }, new string[] { "volvo" }, TestName = "Test first selected with Volvo")]
        [TestCase(new string[] { "Volvo", "Audi" }, new string[] { "volvo","audi" }, TestName = "Test second selected with Volvo and Audi")]
        [TestCase(new string[] { "Volvo", "Audi", "Saab", "Opel" }, new string[] { "volvo","audi","saab","opel" }, TestName = "Test second selected with Volvo, Audi, Saab and Opel")]
        public static void TestCarSelection(string[] CarModels, string[] SelectedCarModels)
        { 
            page.NavigateToPage();
            page.AcceptCookies();
            page.RefreshWebPage();
            //page.GetWait(5);
            page.SelectCarModelFromDropdown(CarModels);
            page.ClickSubmitButton();
            page.GetWait(5);
            page.VerifyResult(SelectedCarModels);
        }
    }
}

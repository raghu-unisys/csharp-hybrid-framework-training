using DocumentFormat.OpenXml.Wordprocessing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class MainPage : WebDriverKeywords
    {
        private By _patientlocator = By.XPath("//div[text()='Patient']");

        private IWebDriver _driver;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        // cretaing a get page title property
        public string GetMainPageTitle
        {
            get { return _driver.Title; }
        }

        public void ClickOnPatientsMenue()
        {
            _driver.FindElement(_patientlocator).Click();
        }

    }
}

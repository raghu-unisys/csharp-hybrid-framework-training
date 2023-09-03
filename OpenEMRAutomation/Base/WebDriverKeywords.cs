using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.Base
{
    public class WebDriverKeywords
    {
        private IWebDriver _driver;

        public WebDriverKeywords(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendTextByLocator(By locator, string text) 
        {
            _driver.FindElement(locator).SendKeys(text);
        }

        public void ClickByLocator(By locator) 
        {
            _driver.FindElement(locator).Click();
        }

        // other keywords for getting text, attribute values, switch tab
        public void SelectDropdownTextByLocator(By locator, string optionText)
        {
            SelectElement selectLanguage = new SelectElement(_driver.FindElement(locator));
            selectLanguage.SelectByText(optionText);

        }
    }
}

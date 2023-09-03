using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace Unisys.OpenEMRAutomation.Pages
{
    public class LoginPage : WebDriverKeywords
    {
        // entering the locaters for various objects so we can reuse it later
        private By _usernameLocator = By.Id("authUser");
        private By _passwordLocator = By.Id("clearPass");
        private By _languageLocator = By.XPath("//select[@name=\"languageChoice\"]");
        private By _loginLocator = By.Id("login-button");
        private By _errorLocator = By.XPath("//p[contains(text(),'Invalid')]");

        private IWebDriver _driver;


        // because we are inherting from parent class at it has a parameterised constructor we need to add base:(parameters) in the child class
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        public void EnterUsername(string username)
        {
            //_driver.FindElement(_usernameLocator).SendKeys(username);
            // We dont have to use base. something but its fine and prevents confusion
            base.SendTextByLocator(_usernameLocator, username);
        }

        public void EnterPassword(string password)
        {
            //_driver.FindElement(_passwordLocator).SendKeys(password);
            SendTextByLocator(_passwordLocator, password);
        }

        public void SelectLanguageByText(string language)
        {

            //SelectElement selectLanguage = new SelectElement(_driver.FindElement(_languageLocator));
            //selectLanguage.SelectByText(language);

            base.SelectDropdownTextByLocator(_languageLocator, language);
        }

        public void ClickOnLogin()
        {
            //_driver.FindElement(_loginLocator).Click();
            base.ClickByLocator(_loginLocator);

        }

        public string GetInvalidErrorMessage()
        {
            return _driver.FindElement(_errorLocator).Text;
        }

        public string GetUsernamePlaceholder()
        {
            return _driver.FindElement(_usernameLocator).GetAttribute("placeholder");
        }
        public string GetPasswordPlaceholder()
        {
            return _driver.FindElement(_passwordLocator).GetAttribute("placeholder");
        }

    }
}

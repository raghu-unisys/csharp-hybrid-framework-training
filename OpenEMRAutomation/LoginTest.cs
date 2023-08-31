using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;
using OpenQA.Selenium.Support.UI;
using NuGet.Frameworks;

namespace Unisys.OpenEMRAutomation
{
    // we are inheriting from the parent class AutomationWrapper so we use the setup and teardown
    public class LoginTest : AutomationWrapper
    {

        // TestCase will considered as an induvidual test method. This is called as Data driven Framework
        [Test]
        [TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        [TestCase("physician", "physician", "English (Indian)", "OpenEMR")]
        public void ValidLoginTest(string username, string password, string language, string expectedTitle)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name=\"languageChoice\"]")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            // waiting for page load to complete

            // validating the window tite
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));

        }
    }
}

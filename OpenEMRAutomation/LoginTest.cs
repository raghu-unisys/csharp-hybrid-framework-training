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
using OpenQA.Selenium.DevTools.V113.Cast;
using Unisys.OpenEMRAutomation.Utilities;

namespace Unisys.OpenEMRAutomation
{
    // we are inheriting from the parent class AutomationWrapper so we use the setup and teardown
    public class LoginTest : AutomationWrapper
    {

        
        // TestCase will considered as an induvidual test method. This is called as Data driven Framework
        //[Test]
        //[TestCase("admin", "pass", "English (Indian)", "OpenEMR")]
        //[TestCase("physician", "physician", "English (Indian)", "OpenEMR")]
        
        // using the data source using object 2D array
        [Test, TestCaseSource(typeof(DataUtils), nameof(DataUtils.ValidLoginDataExcel))]
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

        [Test]
        [TestCase("saul", "saul123", "Danish", "Invalid username or password")]
        [TestCase("john", "john123", "Danish", "Invalid username or password")]
        // passing the data source object
        // Testcase using data source in this case it is the the data object 2D array
        //[Test, TestCaseSource(nameof(ValidLoginData))]

        public void InvalidLoginTest(string username, string password, string language, string expectedError)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);
            driver.FindElement(By.Id("clearPass")).SendKeys(password);
            SelectElement selectLanguage = new SelectElement(driver.FindElement(By.XPath("//select[@name=\"languageChoice\"]")));
            selectLanguage.SelectByText(language);
            driver.FindElement(By.Id("login-button")).Click();

            string actualError = driver.FindElement(By.XPath("//p[contains(text(),'Invalid')]")).Text;
            Assert.That(actualError, Does.Contain(expectedError));
        }
    }
}

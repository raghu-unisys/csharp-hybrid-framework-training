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
using Unisys.OpenEMRAutomation.Pages;

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
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.SelectLanguageByText(language);
            loginPage.ClickOnLogin();

            // waiting for page load to complete

            // validating the window tite
            MainPage mainPage = new MainPage(driver);
            Assert.That(mainPage.GetMainPageTitle, Is.EqualTo(expectedTitle));

        }

        [Test]
        [TestCase("saul", "saul123", "Danish", "Invalid username or password")]
        [TestCase("john", "john123", "Danish", "Invalid username or password")]
        // passing the data source object
        // Testcase using data source in this case it is the the data object 2D array
        //[Test, TestCaseSource(nameof(ValidLoginData))]

        public void InvalidLoginTest(string username, string password, string language, string expectedError)
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.SelectLanguageByText(language);
            loginPage.ClickOnLogin();

            string actualError = loginPage.GetInvalidErrorMessage();
            Assert.That(actualError, Does.Contain(expectedError));
        }
    }
}

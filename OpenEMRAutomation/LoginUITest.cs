using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation
{
    public class LoginUITest
    {
        // we make the driver as an instance varibale so that it can be accessed across all methods
        IWebDriver driver;

        // setup attribute runs before every test. So in this we add the code to open the browser thus reducing repeated code
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://demo.openemr.io/b/openemr";
        }

        // Teardown method runs after every test case. We can use this to quite the browser
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ValidateTitleTest() 
        { 
            string actualTitle = driver.Title;
            Console.WriteLine(actualTitle);

            // validating the title of the webpage
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));

        }

        [Test]
        public void ValidatePlaceholderTest()
        {
            string actualUsernamePlaceholder = driver.FindElement(By.Id("authUser")).GetAttribute("placeholder");
            Assert.That(actualUsernamePlaceholder, Is.EqualTo("Username"));
        }
    }
}

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.Base
{
    // This is a base class that has all the methods for opening closing setup and teardown attributes so we can inherit in test classes
    public class AutomationWrapper
    {
        // we make the driver as an instance varibale so that it can be accessed across all methods
        protected IWebDriver driver;

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

    }
}

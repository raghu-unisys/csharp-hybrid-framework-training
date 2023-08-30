using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisys.Base;

namespace Unisys.OpenEMRAutomation
{
    // we are inheriting from the parent class AutomationWrapper so we use the setup and teardown
    public class LoginTest : AutomationWrapper
    {

        [Test]
        public void ValidLoginTest()
        {
            driver.FindElement(By.Id("authUser")).SendKeys("admin");
            driver.FindElement(By.Id("clearPass")).SendKeys("admin");

        }
    }
}

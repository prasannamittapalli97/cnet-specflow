using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Qualiframe.Web;

namespace QualiframeNunit.ReusableFunctions
{
    public class DriverManager
    {
        public IWebDriver getDriver()
        {
            driver = WebDriver.Driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver;
        }

        private IWebDriver driver;
    }
}

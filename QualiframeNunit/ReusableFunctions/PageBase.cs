using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Qualiframe.Web;

namespace QualiframeNunit.ReusableFunctions
{
    class PageBase
    {
        IWebDriver driver;

        public PageBase(DriverManager manager)
        {
            this.driver = manager.getDriver();
        }
        public IWebElement getWebElementVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public IList<IWebElement> getWebElementsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }

        public void hoverOnElement(IWebElement hoverElement)
        {
            Actions actions = new Actions(WebDriver.Driver);
            actions.MoveToElement(hoverElement).Perform();
        }

    }
}

using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Qualiframe.Web;
using QualiframeNunit.ReusableFunctions;

namespace QualiframeNunit.pages
{
    class TshirtPage:PageBase
    {
        IWebDriver driver;
        public TshirtPage(DriverManager manager) : base(manager)
        {
            driver = manager.getDriver();
        }

       

        public IWebElement tshirtTab()
        {
            return getWebElementVisible(By.XPath("(//a[@title='T-shirts'])[2]"));
        }

        public void HoverOnProductImage()
        {
            Actions actions = new Actions(WebDriver.Driver);
            IWebElement menuOption = WebDriver.Driver.FindElement(By.XPath("//img[@title='Faded Short Sleeve T-shirts']"));
            actions.MoveToElement(menuOption).Perform();
        }

        public IWebElement addToCart()
        {
            return getWebElementVisible(By.XPath("//*[text()='Add to cart']"));
        }

        public IWebElement proceedToCheckout()
        {
            return getWebElementVisible(By.XPath("(//*[contains(text(),'Proceed to checkout')])[last()]"));
        }

        public IWebElement agreeTermsAndCondition()
        {
            return getWebElementVisible(By.XPath("//label[text()='I agree to the terms of service and will adhere to them unconditionally.']"));
        }

        public IWebElement payByCheck()
        {
            return getWebElementVisible(By.XPath("//a[@title='Pay by check.']"));
        }

        public IWebElement confirmOrder()
        {
            return getWebElementVisible(By.XPath("//*[text()='I confirm my order']"));
        }

        public IWebElement backToOrder()
        {
            return getWebElementVisible(By.XPath("//a[@title='Back to orders']"));
        }

        public IList<IWebElement> orders()
        {
            return getWebElementsVisible(By.XPath("//*[@class='color-myaccount']"));
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Qualiframe.Web;
using QualiframeNunit.ReusableFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QualiframeNunit.pages
{
    class ClothingPage : PageBase
    {
        IWebDriver driver;
      
        public ClothingPage(DriverManager manager) : base(manager)
        {
            driver = manager.getDriver();
        }

        public void hoverOnCategories()
        {
            hoverOnElement(WebDriver.Driver.FindElement(By.CssSelector("a.envo-categories-menu-first")));
        }

        public void clickOnClothing()
        {
            IWebElement clothingMenu = WebDriver.Driver.FindElement(By.XPath("//a[@title='Clothing']"));
            clothingMenu.Click();
        }
        public void clickOnWishlist()
        {
            IWebElement wishlist = WebDriver.Driver.FindElement(By.XPath("//a[@title = 'Wishlist']"));
            wishlist.Click();
        }

        public IList<IWebElement> addToWishlist()
        {
            return getWebElementsVisible(By.CssSelector("a.add_to_wishlist"));
        }

        public void addFourProductsToWishList()
        {
            IList<IWebElement> productsWishListButton = addToWishlist();
            int maxLength = 3;
            if(productsWishListButton.Count < 3)
            {
                maxLength = productsWishListButton.Count;
            }
            for (int i=0; i <= maxLength; i++)
            {
                productsWishListButton[i].Click();
                Thread.Sleep(1000);
            }
        }

    }
}

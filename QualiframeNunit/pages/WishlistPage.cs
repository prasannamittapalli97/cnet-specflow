using OpenQA.Selenium;
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
    class WishlistPage : PageBase
    {
        IWebDriver driver;

        public WishlistPage(DriverManager manager) : base(manager)
        {
            driver = manager.getDriver();
        }

        public IList<IWebElement> getWishListElements()
        {
            return getWebElementsVisible(By.CssSelector("tbody.wishlist-items-wrapper tr"));
        }

        public IList<IWebElement> getWishListElementsPrice()
        {
            return getWebElementsVisible(By.CssSelector("td.product-price ins bdi"));
        }
        
        public void clickOnFirstAddToCartButton()
        {
            IWebElement addToCartButton = WebDriver.Driver.FindElement(By.XPath("//a[text() = 'Add to cart']"));
            addToCartButton.Click();
            Thread.Sleep(1000);
        }
        public void clickOnCartButton()
        {
            IWebElement cartButton = WebDriver.Driver.FindElement(By.CssSelector("i.la-shopping-bag"));
            cartButton.Click();
        }

        public IList<IWebElement> getCartItems()
        {
            return getWebElementsVisible(By.CssSelector("tbody tr.cart_item"));
        }
        public void getLeastPriceElement()
        {
            IList<IWebElement> productPrices = getWishListElementsPrice();
            List<String> priceList = new List<String>();
            foreach (IWebElement productprice in productPrices)
            {
                String price = productprice.Text;
                priceList.Add(price);
            }
            priceList.ForEach(price => Console.WriteLine(price));
        }
    }
}

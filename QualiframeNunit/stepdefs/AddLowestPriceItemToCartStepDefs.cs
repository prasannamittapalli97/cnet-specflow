using NUnit.Framework;
using Qualiframe.Web;
using QualiframeNunit.pages;
using QualiframeNunit.ReusableFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QualiframeNunit.stepdefs
{
    [Binding]
    class AddLowestPriceItemToCartStepDefs
    {
        DriverManager context;
        ClothingPage clothingPage;
        WishlistPage wishlistPage;
        public AddLowestPriceItemToCartStepDefs(DriverManager context)
        {
            this.context = context;
        }

        [Given(@"I add four different products to my wish list")]
        public void GivenIAddFourDifferentProductsToMyWishList()
        {
            Browser.Maximise();
            Browser.Navigate("https://testscriptdemo.com");
            clothingPage = new ClothingPage(context);
            wishlistPage = new WishlistPage(context);
            clothingPage.hoverOnCategories();
            clothingPage.clickOnClothing();
            clothingPage.addFourProductsToWishList();
        
        }

        [When(@"I view my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
            clothingPage.clickOnWishlist();
        }

        [Then(@"I find total four selected items in my Wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {
            Assert.AreEqual(4, wishlistPage.getWishListElements().Count);
        }
        [When(@"I add first item in add to cart")]
        public void WhenIAddFirstItemInAddToCart()
        {
            wishlistPage.clickOnFirstAddToCartButton();
            wishlistPage.clickOnCartButton();
        }

        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {
            Assert.AreEqual(1, wishlistPage.getCartItems().Count);
        }


    }
}

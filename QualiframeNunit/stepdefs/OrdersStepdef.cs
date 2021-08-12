using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Qualiframe.Web;
using QualiframeNunit.pages;
using QualiframeNunit.ReusableFunctions;
using TechTalk.SpecFlow;
using Qualiframe.NUnitER.HtmlReport;

namespace QualiframeNunit.stepdefs
{
    [Binding]
    class OrdersStepdef 
    {

        TshirtPage tshirtPage;
        SignInPage signInPage;
        DriverManager context;
        public OrdersStepdef(DriverManager context)
        {
            this.context = context;
            

        }
        
        [Given(@"I am on homepage")]
        public void GivenIAmOnHomepage()
        {
            Browser.Maximise();
            Browser.Navigate("http://automationpractice.com/");
            tshirtPage = new TshirtPage(context);
            signInPage = new SignInPage(context);
            //extTest.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString());
        }

        [When(@"I sign in with (.*) (.*)")]
        public void WhenISignInWith(string username, string password)
        {
            signInPage.signInLink().Click();
            signInPage.username().SendKeys(username);
            signInPage.password().SendKeys(password);
            signInPage.signIn().Click();
            //extTest.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString());

        }

        [When(@"I order a tshirt")]
        public void WhenIOrderATshirt()
        {
            tshirtPage.tshirtTab().Click();
            tshirtPage.HoverOnProductImage();
            tshirtPage.addToCart().Click();
            for (int i = 0; i < 3; i++)
            {
                tshirtPage.proceedToCheckout().Click();
                Thread.Sleep(3000);
            }
            tshirtPage.agreeTermsAndCondition().Click();
            tshirtPage.proceedToCheckout().Click();
            tshirtPage.payByCheck().Click();
            tshirtPage.confirmOrder().Click();
            tshirtPage.backToOrder().Click();
            //addScreenshot(scenario);
        }

        [Then(@"I should see my order in order history")]
        public void ThenIShouldSeeMyOrderInOrderHistory()
        {
            Assert.IsTrue(tshirtPage.orders().Count > 0);
           // addScreenshot(scenario);
        }

        [When(@"I update my personal information")]
        public void WhenIUpdateMyPersonalInformation()
        {
            signInPage.personalInfo().Click();
            signInPage.personalInfoTab().Click();
            signInPage.firstName().Clear();
            signInPage.firstName().SendKeys("testuser changed");
            signInPage.currentPassword().SendKeys("qualitest");
            signInPage.newPassword().SendKeys("qualitest");
            signInPage.confirmPassword().SendKeys("qualitest");
            signInPage.save().Click();
            //addScreenshot(scenario);
        }

        [Then(@"my personal information is saved")]
        public void ThenMyPersonalInformationIsSaved()
        {
            Console.WriteLine("+=+++++++++++++" + signInPage.personalInfo().Text);
            for (int i = 0; i < 5; i++)
            {
                if (signInPage.personalInfo().Text.Contains("Changed"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            Assert.IsTrue(signInPage.personalInfo().Text.Contains("Changed"));
            //addScreenshot(scenario);
        }

    }

}

using OpenQA.Selenium;
using Qualiframe.Web;
using QualiframeNunit.ReusableFunctions;

namespace QualiframeNunit.pages
{
    internal class SignInPage : PageBase
    {
       // public static By button_I_agree = By.XPath("//div[text()='I agree']");
       // public static By field_Search = By.Name("q");

        IWebDriver driver;
        public SignInPage(DriverManager manager):base(manager) {
           driver= manager.getDriver();
        }

        

        public IWebElement signInLink()
        {
            return getWebElementVisible(By.XPath("//*[@class='login']"));
        }

        public IWebElement username()
        {
            return getWebElementVisible(By.Id("email"));
        }

        public IWebElement password()
        {
            return getWebElementVisible(By.Id("passwd"));
        }

        public IWebElement signIn()
        {
            return getWebElementVisible(By.Id("SubmitLogin"));
        }

        public IWebElement personalInfo()
        {
            return getWebElementVisible(By.XPath("//*[@title='View my customer account']"));
        }

        public IWebElement personalInfoTab()
        {
            return getWebElementVisible(By.XPath("//*[text()='My personal information']"));
        }

        public IWebElement firstName()
        {
            return getWebElementVisible(By.Id("firstname"));
        }

        public IWebElement currentPassword()
        {
            return getWebElementVisible(By.Name("old_passwd"));
        }

        public IWebElement newPassword()
        {
            return getWebElementVisible(By.Name("passwd"));
        }

        public IWebElement confirmPassword()
        {
            return getWebElementVisible(By.Name("confirmation"));
        }

        public IWebElement save()
        {
            return getWebElementVisible(By.Name("submitIdentity"));
        }
    }
}

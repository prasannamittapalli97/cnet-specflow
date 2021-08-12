using NUnit.Framework;
using Qualiframe.Web;
using QualiframeNunit.ReusableFunctions;

namespace QualiframeNunit
{
    public class Tests : HooksNunit
    {
        [OneTimeSetUp]
        public void ClassInit1()
        {
            // Executes once for the test class. (Optional)
        }
        [SetUp]
        public void TestInit()
        {
            // Runs before each test. (Optional)
        }
        [Test]
        public void TestMethod()
        {
            extTest = extReports.CreateTest(TestContext.CurrentContext.Test.Name);
            //Actual Test code
            Browser.Maximise();
            Browser.Navigate("https://google.com");
            string title = WebDriver.Driver.Title;

            if (title.Equals("Google"))
            {
                extTest.Pass("Page title validated and it is shown as expected");
            }
            else
            {
                extTest.Fail("Page title validated and it is not shown as expected. Expected is :Google Actual is:" + title);
            }
            extTest.CreateNode("Test", "Test");

        }
        [TearDown]
        public void TestCleanup1()
        {
            // Runs after each test. (Optional)
        }
        [OneTimeTearDown]
        public void ClassCleanup1()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
           // Browser.Quit();
        }
    }
}
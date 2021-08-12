using NUnit.Framework;
using Qualiframe.Web;
using Qualiframe.NUnitER.HtmlReport;
namespace QualiframeNunit.ReusableFunctions
{
    
    public class HooksNunit : HtmlReport
    {
        [OneTimeSetUp]
        public void ClassInit()
        {
            SetExtRepHostname("127.0.0.1");
            SetExtRepEnvironment("Local Development");
            ConfigureExtentReport();
        }
        
        [TearDown]
        public void TestCleanup()
        {
            // Runs after each test. (Optional)
            extTest.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString());

        }
        [OneTimeTearDown]
        public void ClassCleanup()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
            if (extReports != null)

                extReports.Flush();


            Browser.Quit();
        }

        
    }
}

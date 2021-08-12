using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Qualiframe.NUnitER.HtmlReport;
using Qualiframe.Web;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;

namespace QualiframeNunit.ReusableFunctions
{
    [Binding]
    class HooksSpecflow : HtmlReport
    {
        private readonly FeatureContext _featureContext;
        private AventStack.ExtentReports.ExtentTest currentScenarioName;
        private static AventStack.ExtentReports.ExtentTest featureName;
        private readonly IObjectContainer _objectContainer;


        public HooksSpecflow(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            SetExtRepHostname("127.0.0.1");
            SetExtRepEnvironment("Local Development");
            ConfigureExtentReport();
            //extTest = extReports.CreateTest(TestContext.CurrentContext.Test.Name);
            Console.WriteLine("beforefeature");
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
           // extTest.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString());

        }

        [BeforeFeature]
       // [Obsolete]
        public static void BeforeFeature()
        {
            //Create dynamic feature name
            featureName = extReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            //Create dynamic scenario name
            currentScenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterScenario]
        public void TestStop()
        {

        }
        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioStepContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    currentScenarioName.CreateNode<And>(ScenarioContext.Current.StepContext.StepInfo.Text);
            }

            //Dont Take screenshots for non UI based scenarios 
            else if (ScenarioStepContext.Current.TestError != null && !((IList<string>)ScenarioContext.Current.ScenarioInfo.Tags).Contains("ui"))
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.StackTrace);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.StackTrace);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.StackTrace);

                //Take Screenshot
                //DriverFactory.Instance.Driver.CaptureScreenShot(TestContext.CurrentContext.Test.MethodName);
            }
            else if (ScenarioStepContext.Current.TestError != null && ((IList<string>)ScenarioContext.Current.ScenarioInfo.Tags).Contains("ui"))
            {
                //var image = DriverFactory.Instance.Driver.CaptureScreenshotAndEncode(TestContext.CurrentContext.Test.MethodName);

                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.Message);
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.Message);
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(ScenarioContext.Current.StepContext.StepInfo.Text).Fail(ScenarioStepContext.Current.TestError.Message);


                //Take Screenshot
                //DriverFactory.Instance.Driver.CaptureScreenShot(TestContext.CurrentContext.Test.MethodName);
            }
            else if (ScenarioContext.Current.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

            }

            extTest = featureName;
            //MapNunitResultToExtentReport(Browser.ScreenShot.Get.Object());

            // featureName.Log(AventStack.ExtentReports.Status.Info, "Screenshot:" + featureName.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString()));
            featureName.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString());
            //currentScenarioName.CreateNode<Then>("Screenshot:" + extTest.AddScreenCaptureFromBase64String("data:image/png;base64," + Browser.ScreenShot.Get.Base64String().ToString()));
        }


        [BeforeScenario]
        public void Initialize()
        {
            //SelectBrowser(BrowserType.Firefox);
            //Create dynamic scenario name
           // scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {

            if (extReports != null)

                extReports.Flush();


            Browser.Quit();
        }
    }
}

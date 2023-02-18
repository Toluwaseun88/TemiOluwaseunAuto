using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TemiOluwaseunAuto.BaseClass;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace CareersWebsiteAuto.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private BaseTest _basetest;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public Hooks1(BaseTest baseTest) => _basetest = baseTest;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenariocontext)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            option.AddArguments("--disable-notifications");
            //option.AddArguments("--headless");

            _basetest.Driver = new ChromeDriver(option);
            scenario = featureName.CreateNode(scenariocontext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _basetest.Driver.Quit(); 
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\temitope.oluwaseun\source\repos\TemiOluwaseunAuto\TemiOluwaseunAuto\Reports\index.html");
            
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {

            var stepType = sc.StepContext.StepInfo.StepDefinitionType.ToString();
            var pendingDef = sc.ScenarioExecutionStatus.ToString();

            if (sc.TestError == null) 
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text);
            }
            else if (sc.TestError != null)
            {
                var mediaEntity = _basetest.CaptureScreenshotAndReturnModel(sc.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message, mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message, mediaEntity);
            }


            if (pendingDef == "StepDefinitionPending")
            {
                if (stepType == "Given")

                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            }

        }

        [BeforeFeature]
     
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }

   
    }
}

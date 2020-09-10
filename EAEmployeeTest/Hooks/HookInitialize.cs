using EAAutoFramework.Base;
using TechTalk.SpecFlow;
using EAAutoFramework.Helpers;
using EAAutoFramework.Config;
using AventStack.ExtentReports;
using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace EAEmployeeTest.Hooks
{

    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        [BeforeTestRun]
        public static void TestStart()
        {
            InitializeSettings();
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C: \Users\dh001mi\source\repos\EAPOM\EAEmployeeTest\ExtentReport.Html");
            extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void AfterEachStep()
        {
            var stepName = ScenarioContext.Current.StepContext.StepInfo.Text;
            var featureName = FeatureContext.Current.FeatureInfo.Title;
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException); ;
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException); ;
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException); ;
            }
        }

        [BeforeScenario]
        public void Initialize()
        {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void TestStop()
        {
            extent.Flush();
        }
    }
}

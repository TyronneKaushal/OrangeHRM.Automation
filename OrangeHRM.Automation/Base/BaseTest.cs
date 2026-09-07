using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHRM.Automation.Config;
using OrangeHRM.Automation.Drivers;
using OrangeHRM.Automation.Utilities;

namespace OrangeHRM.Automation.Base
{
    public class BaseTest
    {
        protected IWebDriver? Driver => DriverManager.TryGetDriver();
        protected ExtentTest ExtentTest = null!;

        [SetUp]
        public void Setup()
        {
            var testName = TestContext.CurrentContext.Test.Name;

            Logger.Info(
                    $"Starting test: {testName} " +
                    $"(Attempt {TestContext.CurrentContext.CurrentRepeatCount + 1})");

            ExtentTest = ReportManager.CreateTest(testName);

            var driver = DriverFactory.CreateDriver(
                ConfigReader.Browser,
                ConfigReader.Headless);

            DriverManager.SetDriver(driver);
        }

        [TearDown]
        public void TearDown()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Error(
                     $"Test failed: {testName} " +
                     $"(Attempt {TestContext.CurrentContext.CurrentRepeatCount + 1}). " +
                     $"Failure: {message}");

                var screenshotPath =
                    ScreenshotHelper.Capture(Driver, testName);

                ExtentTest.AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                Logger.Info($"Test passed: {testName}");

                ExtentTest.Pass("Test passed successfully.");
            }

            DriverManager.QuitDriver();
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ReportManager.Flush();
        }
    }
}
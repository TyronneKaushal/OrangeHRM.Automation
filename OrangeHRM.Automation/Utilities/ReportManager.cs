using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace OrangeHRM.Automation.Utilities
{
    public static class ReportManager
    {
        private static readonly ExtentReports _extentReports;
        private static readonly string _reportPath;

        static ReportManager()
        {
            var reportsDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Reports");

            Directory.CreateDirectory(reportsDirectory);

            _reportPath = Path.Combine(
                reportsDirectory,
                "AutomationReport.html");

            var sparkReporter = new ExtentSparkReporter(_reportPath);

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(sparkReporter);
        }

        public static ExtentTest CreateTest(string testName)
        {
            return _extentReports.CreateTest(testName);
        }

        public static void Flush()
        {
            _extentReports.Flush();
        }
    }
}
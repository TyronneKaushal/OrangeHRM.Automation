using OpenQA.Selenium;

namespace OrangeHRM.Automation.Utilities
{
    public static class ScreenshotHelper
    {
        public static string Capture(IWebDriver driver, string testName)
        {
            if (driver is not ITakesScreenshot screenshotDriver)
            {
                throw new InvalidOperationException(
                    "The current WebDriver does not support screenshots.");
            }

            var screenshotsDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Screenshots");

            Directory.CreateDirectory(screenshotsDirectory);

            var safeTestName = string.Join(
                "_",
                testName.Split(Path.GetInvalidFileNameChars()));

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var fileName = $"{safeTestName}_{timestamp}.png";

            var filePath = Path.Combine(
                screenshotsDirectory,
                fileName);

            screenshotDriver
                .GetScreenshot()
                .SaveAsFile(filePath);

            return filePath;
        }
    }
}
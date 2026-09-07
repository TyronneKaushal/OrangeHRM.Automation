using OpenQA.Selenium;

namespace OrangeHRM.Automation.Drivers
{
    public static class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver> _driver = new();

        public static IWebDriver Driver =>
            _driver.Value
            ?? throw new InvalidOperationException(
                "WebDriver has not been initialized.");

        public static IWebDriver? TryGetDriver()
        {
            return _driver.Value;
        }

        public static void SetDriver(IWebDriver driver)
        {
            _driver.Value = driver;
        }

        public static void QuitDriver()
        {
            if (_driver.Value is null)
            {
                return;
            }

            _driver.Value.Quit();
            _driver.Value.Dispose();
            _driver.Value = null;
        }
    }
}
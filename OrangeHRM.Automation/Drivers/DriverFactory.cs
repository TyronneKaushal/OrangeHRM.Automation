using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OrangeHRM.Automation.Models;

namespace OrangeHRM.Automation.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(
            BrowserType browserType,
            bool headless)
        {
            return browserType switch
            {
                BrowserType.Chrome => CreateChromeDriver(headless),
                BrowserType.Edge => CreateEdgeDriver(headless),
                BrowserType.Firefox => CreateFirefoxDriver(headless),

                _ => throw new ArgumentOutOfRangeException(
                    nameof(browserType),
                    browserType,
                    "Unsupported browser type.")
            };
        }

        private static IWebDriver CreateChromeDriver(bool headless)
        {
            var options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            return new ChromeDriver(options);
        }

        private static IWebDriver CreateEdgeDriver(bool headless)
        {
            var options = new EdgeOptions();

            if (headless)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            return new EdgeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver(bool headless)
        {
            var options = new FirefoxOptions();

            if (headless)
            {
                options.AddArgument("--headless");
            }

            return new FirefoxDriver(options);
        }
    }
}
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
// using SeleniumExtras.WaitHelpers; // avoid dependency on SeleniumExtras ExpectedConditions

namespace OrangeHRM.Automation.Utilities
{
    public class WaitHelper
    {
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver, int timeoutInSeconds = 10)
        {
            _wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    return null;
                }
                catch (OpenQA.Selenium.StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return (element != null && element.Displayed && element.Enabled) ? element : null;
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    return null;
                }
                catch (OpenQA.Selenium.StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
    }
}
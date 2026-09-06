using OpenQA.Selenium;
using OrangeHRM.Automation.Utilities;

namespace OrangeHRM.Automation.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WaitHelper Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WaitHelper(driver);
        }
    }
}
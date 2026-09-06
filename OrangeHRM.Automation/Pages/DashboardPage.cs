using OpenQA.Selenium;
using OrangeHRM.Automation.Utilities;

namespace OrangeHRM.Automation.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly By DashboardHeader =
            By.XPath("//h6[normalize-space()='Dashboard']");

        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsDisplayed()
        {
            Logger.Info("Checking whether Dashboard is displayed.");

            return Wait.WaitForElementVisible(DashboardHeader).Displayed;
        }
    }
}
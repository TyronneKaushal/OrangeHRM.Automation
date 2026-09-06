using OpenQA.Selenium;
using OrangeHRM.Automation.Config;
using OrangeHRM.Automation.Utilities;

namespace OrangeHRM.Automation.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By UsernameInput =
            By.XPath("//input[@placeholder='Username']");

        private readonly By PasswordInput =
            By.XPath("//input[@placeholder='Password']");

        private readonly By LoginButton =
            By.XPath("//button[normalize-space()='Login']");

        private readonly By InvalidCredentialsMessage =
            By.XPath("//p[contains(@class,'oxd-alert-content-text')]");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public LoginPage Open()
        {
            Logger.Info("Opening OrangeHRM application.");

            Driver.Navigate().GoToUrl(ConfigReader.BaseUrl);

            return this;
        }

        public void EnterUsername(string username)
        {
            Logger.Info("Entering username.");

            Wait.WaitForElementVisible(UsernameInput)
                .SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Logger.Info("Entering password.");

            Wait.WaitForElementVisible(PasswordInput)
                .SendKeys(password);
        }

        public DashboardPage ClickLogin()
        {
            Logger.Info("Clicking Login button.");

            Wait.WaitForElementClickable(LoginButton)
                .Click();

            return new DashboardPage(Driver);
        }

        public DashboardPage Login(string username, string password)
        {
            Logger.Info("Performing login.");

            EnterUsername(username);
            EnterPassword(password);

            return ClickLogin();
        }

        public string GetErrorMessage()
        {
            Logger.Info("Reading login error message.");

            return Wait.WaitForElementVisible(InvalidCredentialsMessage).Text;
        }
    }
}
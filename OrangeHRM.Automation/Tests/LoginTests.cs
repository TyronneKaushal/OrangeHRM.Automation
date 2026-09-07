using FluentAssertions;
using NUnit.Framework;
using OrangeHRM.Automation.Base;
using OrangeHRM.Automation.Config;
using OrangeHRM.Automation.Pages;
using OrangeHRM.Automation.Utilities;

namespace OrangeHRM.Automation.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : BaseTest
    {
        [Test]
        [Retry(2)]
        public void ValidLogin()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Open();

            var dashboardPage = loginPage.Login(
                ConfigReader.Username,
                ConfigReader.Password);

            dashboardPage.IsDisplayed().Should().BeTrue();
        }

        [TestCaseSource(typeof(TestDataReader), nameof(TestDataReader.InvalidPasswords))]
        public void InvalidPassword_ShouldDisplayErrorMessage(string password)
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Open();

            loginPage.EnterUsername(ConfigReader.Username);
            loginPage.EnterPassword(password);
            loginPage.ClickLogin();

            var errorMessage = loginPage.GetErrorMessage();

            errorMessage.Should().Contain("Invalid credentials");
        }
    }
}
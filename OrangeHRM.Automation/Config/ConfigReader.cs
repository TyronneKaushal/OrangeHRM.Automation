using Microsoft.Extensions.Configuration;
using OrangeHRM.Automation.Models;

namespace OrangeHRM.Automation.Config
{
    public static class ConfigReader
    {
        private static readonly IConfiguration Configuration =
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        public static string BaseUrl =>
            Configuration["Application:BaseUrl"]
            ?? throw new InvalidOperationException(
                "Application:BaseUrl is not configured.");

        public static string Username =>
            Configuration["Credentials:Username"]
            ?? throw new InvalidOperationException(
                "Credentials:Username is not configured.");

        public static string Password =>
            Configuration["Credentials:Password"]
            ?? throw new InvalidOperationException(
                "Credentials:Password is not configured.");

        public static BrowserType Browser =>
            Enum.TryParse(
                Configuration["Application:Browser"],
                true,
                out BrowserType browser)
                ? browser
                : throw new InvalidOperationException(
                    "Application:Browser is not configured correctly.");

        public static bool Headless =>
            bool.TryParse(
                Configuration["Application:Headless"],
                out var headless)
                ? headless
                : false;
    }
}
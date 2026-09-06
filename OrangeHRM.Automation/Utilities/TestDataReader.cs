using System.Text.Json;

namespace OrangeHRM.Automation.Utilities
{
    public static class TestDataReader
    {
        private static readonly JsonDocument TestData;

        static TestDataReader()
        {
            var filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Resources",
                "TestData.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    $"Test data file was not found: {filePath}");
            }

            TestData = JsonDocument.Parse(
                File.ReadAllText(filePath));
        }

        public static string InvalidPassword =>
            TestData.RootElement
                .GetProperty("Login")
                .GetProperty("InvalidPassword")
                .GetString()
            ?? throw new InvalidOperationException(
                "Login.InvalidPassword is not configured.");

        public static IEnumerable<string> InvalidPasswords
        {
            get
            {
                foreach (var password in TestData.RootElement
                             .GetProperty("Login")
                             .GetProperty("InvalidPasswords")
                             .EnumerateArray())
                {
                    yield return password.GetString()
                        ?? throw new InvalidOperationException(
                            "Invalid password value is null.");
                }
            }
        }
    }
}
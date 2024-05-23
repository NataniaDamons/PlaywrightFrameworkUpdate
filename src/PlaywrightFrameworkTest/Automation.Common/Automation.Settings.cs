using PlaywrightFrameworkTest.Automation.Common.Configuration;
using Microsoft.Extensions.Configuration;


namespace PlaywrightFrameworkTest.Automation.Common
{
    // Represents an abstract base class for automation tests using Playwright.
    public partial class Automation
    {
        // Holds the global settings for the tests.
        private TestSettings? _settings;
        // Retrieves settings of the specified type from the configuration files.
        private TSettings? GetSettings<TSettings>(string resourceName)
        {
            // Determine the environment name from environment variables
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");// nb this will change depending on your environmental variable

           // Build the configuration from multiple JSON files 
            var builder = new ConfigurationBuilder()
           .AddJsonFile($"{resourceName}.json")                                                // Load default settings file  // looks for the default settings file
           .AddJsonFile($"{resourceName}.local.json", optional: true, reloadOnChange: true)    // load local settings
           .AddJsonFile($"{resourceName}.{environmentName}.json", optional: true);             // load an settings file for the environment
            var configuration = builder.Build();
            return configuration.Get<TSettings>();
        }
    }
}
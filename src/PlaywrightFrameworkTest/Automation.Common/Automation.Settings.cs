using PlaywrightFrameworkTest.Automation.Common.Configuration;
using Microsoft.Extensions.Configuration;


namespace PlaywrightFrameworkTest.Automation.Common
{
    public partial class Automation
    {
        private TestSettings? _settings;
        private TSettings? GetSettings<TSettings>(string resourceName)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");// nb this will change depending on your environmental variable

            var builder = new ConfigurationBuilder()
           .AddJsonFile($"{resourceName}.json")                                                // looks for the default settings file
           .AddJsonFile($"{resourceName}.local.json", optional: true, reloadOnChange: true)    // load local settings
           .AddJsonFile($"{resourceName}.{environmentName}.json", optional: true);             // load an settings file for the environment
            var configuration = builder.Build();
            return configuration.Get<TSettings>();
        }
    }
}
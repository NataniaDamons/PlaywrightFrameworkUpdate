using System.Diagnostics;
using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Configuration;
using PlaywrightFrameworkTest.Automation.Common.Extensions;
using PlaywrightFrameworkTest.Automation.Common.Utilities;


namespace PlaywrightFrameworkTest.Automation.Common;
// Represents an abstract base class for automation tests using Playwright.
public partial class Automation
{
    // Sets up global settings and initializes the Playwright and browser instances.
    // This method runs once before any tests are executed.
    [OneTimeSetUp]
    public async Task SetUpGlobals()
    {
        _settings = GetSettings<TestSettings>("Settings");
        // Create a new instance of Playwright
        _playwright = await Playwright.CreateAsync();

        var _browserType = _settings.Browser.Type.ToLower();
        IBrowserType? browser = _browserType switch
        {
            "chromium" => _playwright.Chromium,
            "firefox" =>  _playwright.Firefox,
            "webkit" => _playwright.Webkit,
            _ => throw new ArgumentException(
                $"Unsupported browser type: {_browserType}"
            )
        };
        // Launch a new browser instance with specified options

        _browser = await browser.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = _settings.Debugging!.HeadlessMode,
            SlowMo = _settings.OperationSpeed
        });

    }
    
}


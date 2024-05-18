using System.Diagnostics;
using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Configuration;
using PlaywrightFrameworkTest.Automation.Common.Extensions;
using PlaywrightFrameworkTest.Automation.Common.Utilities;


namespace PlaywrightFrameworkTest.Automation.Common;

public partial class Automation
{
    [OneTimeSetUp]
    public async Task SetUpGlobals()
    {
        _settings = GetSettings<TestSettings>("settings");
        //Playwright
        _playwright = await Playwright.CreateAsync();
        //browser
        var chromium = _playwright.Chromium;
        _browser = await chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = _settings.Debugging!.HeadlessMode,
            SlowMo = _settings.OperationSpeed
        });

    }
}


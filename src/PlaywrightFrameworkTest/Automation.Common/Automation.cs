using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Utilities;
using PlaywrightFrameworkTest.Automation.Common.Exceptions;



namespace PlaywrightFrameworkTest.Automation.Common
{
    [TestFixture]
    public abstract partial class Automation
    {
        // The trick here is the static keyword
        private IPlaywright _playwright = null!;
        private IBrowser _browser = null!;
        protected IPage Page = null!;
        //Store the name of the current test 
        //This is useful for naming the traceviewer files
        private static string TestName => TestContext.CurrentContext.Test.Name;
        // Run ahead of each test
        // Creates a new page object... therefore you will be enforcing the GOTO on each of your test as the first
        [SetUp]
        public async Task OnTestRunSetup()
        {
            _playwright = await Playwright.CreateAsync();
           _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

            var context = await _browser.NewContextAsync(
                new BrowserNewContextOptions
                {

                    ViewportSize = new ViewportSize
                    {
                        Height = _settings.Viewport!.Height,
                        Width = _settings.Viewport.Width
                    }
                }
            );
            
            Page = await context.NewPageAsync();
            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            //optional paramater to add if you want all your tests to start by going to the predefined test url
            if (_settings.TestUrl != null ){
                await Page.GotoAsync(_settings!.TestUrl!);
            }
            
        }
        [TearDown]
        public async Task TearDown()
        {
            try
            {
                if (Page?.Context != null)
                {
                    // Find the current directory that points to the Bin Folder
                    // Create a substring that points to PlaywrightFrameworkTest
                    var projectDirectory = TraceFileSetup.SetupTraceFile();
                    var outputLocation = $"{projectDirectory}/TraceFiles/{TestName}.zip";
                    // Stop tracing and save the trace file
                    await Page.Context.Tracing.StopAsync(new TracingStopOptions
                    {
                        Path = outputLocation
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during tracing stop: {ex}");
            }
            finally
            {
                // Ensure Page is closed even if an exception occurs
                if (Page != null)
                {
                    try
                    {
                        await Page.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception during page close: {ex}");
                    }
                }
                // Ensure context and browser are closed as well
                if (Page?.Context != null)
                {
                    try
                    {
                        await Page.Context.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception during context close: {ex}");
                    }
                }
                if (_browser != null)
                {
                    try
                    {
                        await _browser.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception during browser close: {ex}");
                    }
                }
            }
        }
    }
}
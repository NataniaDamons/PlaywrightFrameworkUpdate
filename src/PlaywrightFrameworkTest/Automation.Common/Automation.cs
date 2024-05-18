using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Utilities;
using PlaywrightFrameworkTest.Automation.Common.Exceptions;



namespace PlaywrightFrameworkTest.Automation.Common
{
    [TestFixture]
    public abstract partial class Automation
    {
        // The trick here is the static keyword
        private static IPlaywright _playwright = null!;
        private static IBrowser _browser = null!;
        protected IPage Page = null!;
        //Store the name of the current test 
        //This is useful for naming the traceviewer files
        private string TestName => TestContext.CurrentContext.Test.Name;
        // Run ahead of each test
        // Creates a new page object... therefore you will be enforcing the GOTO on each of your test as the first
        [SetUp]
        public async Task OnTestRunSetup()
        {

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

                Title = TestName,
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            //optional paramater to add if you want all your tests to start by going to the predefined test url
            if (_settings.TestUrl == null! ){
                await Page.GotoAsync(_settings!.TestUrl!);
            }
            
        }
        [TearDown]
        public async Task TearDown()
        {
            //find the current directory that points to the Bin Folder
            //Create a substring that points to PlaywrightFrameworkTest
            var projectDirectory = TraceFileSetup.SetupTraceFile();
            var OutputLocation = $"{projectDirectory}/TraceFiles/{TestName}.zip";

            await Page.Context.Tracing.StopAsync(new()
            {
                Path = OutputLocation
            });
            await Page.CloseAsync();
        }
    }
}
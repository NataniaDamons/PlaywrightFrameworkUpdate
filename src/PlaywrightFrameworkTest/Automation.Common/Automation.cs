using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Utilities;
using PlaywrightFrameworkTest.Automation.Common.Exceptions;
namespace PlaywrightFrameworkTest.Automation.Common
{
   /// Represents an abstract base class for automation tests using Playwright.
   [TestFixture]
   public abstract partial class Automation
   {
       /// The Playwright instance.
       private IPlaywright _playwright = null!;
       /// The browser instance.
       private IBrowser _browser = null!;
       /// The page instance.
       protected IPage Page = null!;
       /// Gets the name of the current test.
       /// This is useful for naming the trace viewer files.
       private string TestName => TestContext.CurrentContext.Test.Name;

       /// Sets up the test environment before each test run.
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

           // Start tracing
           await context.Tracing.StartAsync(new TracingStartOptions
           {
               Screenshots = true,
               Snapshots = true,
               Sources = true
           });

           // Optional parameter to add if you want all your tests to start by going to the predefined test URL
           if (_settings.TestUrl != null)
           {
               await Page.GotoAsync(_settings!.TestUrl!);
           }
       }

       /// Tears down the test environment after each test run.
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
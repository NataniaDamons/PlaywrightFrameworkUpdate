
using System.Diagnostics;



namespace PlaywrightFrameworkTest
{
    public class FirstPlaywrightScript : Automation.Common.Automation
    {

        [Test]
        public async Task CreateTestName()
        {
            try
            {
                // Your script starts here 
                await Page.GotoAsync("https://playwright.dev/dotnet");
                GoogleFixture loc = new GoogleFixture();
                await Page.ClickAsync(loc.SearchLocator);
            }
            catch (Exception message)
            {
                Debug.WriteLine(message);
                throw;
            }
        }
    }
}


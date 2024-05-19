using Microsoft.Playwright;
using PlaywrightFrameworkTest.Automation.Common.Utilities;

namespace PlaywrightFrameworkTest.Automation.Common.Pages
{
    public class GoogleMapsPage : Automation
    {
        public async Task SearchAddress(IPage page, string address)
       {
           await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { Name = "Sign in" })).ToBeVisibleAsync(new() { Timeout = 1000 * 20 });
           await page.GetByLabel("Search Google Maps").FillAsync(address);
           await page.GetByRole(AriaRole.Gridcell, new() { Name = address }).ClickAsync();
       }

    }

}
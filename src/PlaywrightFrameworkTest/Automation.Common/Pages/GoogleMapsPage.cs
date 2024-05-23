using System.Diagnostics;
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

        public async Task<bool> ValidateAddress(IPage page, string address)
        {
            await Assertions.Expect(page.Locator(".DUwDvf.lfPIob")).ToBeVisibleAsync(new() { Timeout = 1000 * 20 });
            var searchBoxValue = await page.TextContentAsync(".DUwDvf.lfPIob");
            return searchBoxValue != null && address.Contains(searchBoxValue);
        }

        public async Task SearchInvalidAddress(IPage page, string address)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { Name = "Sign in" })).ToBeVisibleAsync(new() { Timeout = 1000 * 20 });
            await page.GetByLabel("Search Google Maps").FillAsync(address);
            await page.Keyboard.PressAsync("Enter");
        }
  
        public async Task<bool> ValidateinvalidAddress(IPage page, string address)
        {
            await Assertions.Expect(page.GetByText("Make sure your search is spelled correctly. Try adding a city, state, or zip cod")).ToBeVisibleAsync(new() { Timeout = 1000 * 20 });
            var searchBoxValue = await page.TextContentAsync(".Q2vNVc");
            return searchBoxValue != null && searchBoxValue.Contains(address);
        }
    }
}

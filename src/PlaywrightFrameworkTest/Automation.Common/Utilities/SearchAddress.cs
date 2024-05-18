using Microsoft.Playwright;

namespace PlaywrightFrameworkTest.Automation.Common.Utilities{

    public class SearchAddress {
        //Enter address and search
        public async Task Search(IPage page){
            await page.GotoAsync("https://www.google.com/maps");
            await Assertions.Expect(page.GetByRole(AriaRole.Link, new() { Name = "Sign in" })).ToBeVisibleAsync(new() {Timeout = 1000 * 10});
            await page.GetByLabel("Search Google Maps").FillAsync("344 Crawford Ave, Eesrste");
            await page.GetByRole(AriaRole.Gridcell, new() { Name = "344Crawford Ave Eersterust, Pretoria" }).ClickAsync();
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "344 Crawford Ave" }).GetByText("344 Crawford Ave")).ToBeVisibleAsync(new() {Timeout = 1000 * 10});
        }

    }

}
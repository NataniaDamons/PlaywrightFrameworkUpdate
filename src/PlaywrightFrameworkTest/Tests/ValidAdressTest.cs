using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaywrightFrameworkTest;
using PlaywrightFrameworkTest.Automation;
using PlaywrightFrameworkTest.Automation.Common.Utilities;
using System.Collections.Generic;
using System.Diagnostics;
using PlaywrightFrameworkTest.Automation.Common.Pages;
using Microsoft.Playwright;

namespace PlaywrightFrameworkTest
{
    public class ValidateAddressTest : Automation.Common.Automation
    {
        [Test]
        [TestCaseSource(typeof(ValidAddressDataProvider), nameof(ValidAddressDataProvider.SearchAddresses))]
        public async Task SearchAddressTest(string address)
        {
            var googleMapsPage = new GoogleMapsPage();
            await googleMapsPage.SearchAddress(Page, address);
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var validAdress = await googleMapsPage.ValidateAddress(Page, address);
            Assert.That(validAdress, Is.True, "This is not a valid address");
        }
    }
}
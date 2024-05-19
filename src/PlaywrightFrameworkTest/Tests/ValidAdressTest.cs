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

namespace PlaywrightFrameworkTest
{
    public class ValidateAddressTest : Automation.Common.Automation
    {
        [Test]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.SearchAddresses))]
        public async Task SearchAddressTest(string address)
        {
            var googleMapsPage = new GoogleMapsPage();
            await googleMapsPage.SearchAddress(Page, address);
            var validAdress = await googleMapsPage.ValidateAddress(Page, address);
            Assert.That(validAdress, Is.True, "This is not a valid address");
        }
    }
}
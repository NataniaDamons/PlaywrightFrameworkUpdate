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
    public class SearchAdressTest : Automation.Common.Automation
    {
        [Test]
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.SearchAddresses))]
        public async Task SearchAddressTest(string address)
        {
            var googleMapsPage = new GoogleMapsPage();
            Debug.WriteLine($"Address: {address}");
            await googleMapsPage.SearchAddress(Page, address);
        }
    }
}
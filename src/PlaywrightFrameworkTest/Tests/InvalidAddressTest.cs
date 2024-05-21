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
    public class InvalidateAddressTest : Automation.Common.Automation
    {
        [Test]
        [TestCaseSource(typeof(InvalidAddressDataProvider), nameof(InvalidAddressDataProvider.SearchInvalidAddresses))]
        public async Task SearchAddressTest(string address)
        {
            var googleMapsPage = new GoogleMapsPage();
            await googleMapsPage.SearchInvalidAddress(Page, address);
            var invalidAdress = await googleMapsPage.ValidateinvalidAddress(Page, address);
            Assert.That(invalidAdress, Is.True, "This is not a valid address");
        }

        [Test]
        [TestCaseSource(typeof(InvalidAddressDataProvider), nameof(InvalidAddressDataProvider.SpecialCharacterAddresses))]
        public async Task SearchSpecialCharacterAddressTest(string address)
        {
            var googleMapsPage = new GoogleMapsPage();
            await googleMapsPage.SearchInvalidAddress(Page, address);
            var invalidAdress = await googleMapsPage.ValidateinvalidAddress(Page, address);
            Assert.That(invalidAdress, Is.True, "This is not a valid address");
        }

    }
}
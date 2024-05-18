
using System.Diagnostics;
using PlaywrightFrameworkTest.Automation.Common.Utilities;



namespace PlaywrightFrameworkTest
{
    public class GoogleMaps : Automation.Common.Automation
    {

        [Test]
        public async Task SearchAddress()
        {
            SearchAddress address = new SearchAddress(); 
            try
            {
                await address.Search(Page);
 
            }
            catch (Exception message)
            {
                Debug.WriteLine(message);
                throw;
            }
        }
    }
}


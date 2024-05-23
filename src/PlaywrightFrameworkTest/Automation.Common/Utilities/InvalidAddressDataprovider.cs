
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    
    public class InvalidAddressDataProvider
    {
        public static IEnumerable<object[]>SearchInvalidAddresses()
        {
            yield return new object[] {"12345678 Alphabt Rd"};
            yield return new object[] {"5698569 SimSim Rd"}; 
        }

        public static IEnumerable<object[]> SpecialCharacterAddresses()
        {
           yield return new object[] { "#$%^&*()" };
           yield return new object[] { "!!!@@@###" }; 
           yield return new object[] { "        " }; 
        }
    } 
}
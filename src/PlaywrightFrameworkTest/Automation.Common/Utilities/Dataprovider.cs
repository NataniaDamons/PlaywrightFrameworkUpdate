
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    
    public class DataProvider
    {
        public static IEnumerable<object[]>SearchAddresses()
        {
            yield return new object[] {"Menlyn Park Shopping Centre Lois Avenue, Menlyn, Pretoria"};
            yield return new object[] {"1241 Embankment Rd, Zwartkop, Centurion, 0051"};
            yield return new object[] {"Christina De Wit Ave Groenkloof 358-Jr, Pretoria, 0027"};
            yield return new object[] {"Pretoria Art Museum Wessels Street, Arcadia, Pretoria"}; 
        }
    }
}
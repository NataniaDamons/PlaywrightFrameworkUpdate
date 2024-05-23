
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    
    public class ValidAddressDataProvider
    {
        public static IEnumerable<object[]>SearchAddresses()
        {
            yield return new object[] {"Menlyn Park Shopping Centre Lois Avenue, Menlyn, Pretoria"};
            yield return new object[] {"Voortrekker Monument Monument Street, Groenkloof 358-Jr, Pretoria"};
            yield return new object[] {"Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahu"};
            yield return new object[] {"     Pretoria Art Museum Wessels Street, Arcadia, Pretoria    "}; 
        }
    }
}
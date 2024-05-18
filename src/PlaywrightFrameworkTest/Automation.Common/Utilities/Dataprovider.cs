
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    public class DataProvider
    {
        public static IEnumerable<object[]>GetNames()
        {
            var fname = CreateCustomer.GenerateName();
            yield return new object[] {"Stan" , 10 , "01/08/1993",fname};
            yield return new object[] {"Van" , 11 , "01/08/1994",CreateCustomer.GenerateName()};
            yield return new object[] {"Pan" , 12 , "01/08/1995", CreateCustomer.GenerateName()};
            yield return new object[] {"Dan" , 13 , "01/08/1996", CreateCustomer.GenerateName()};

        }
    }
}
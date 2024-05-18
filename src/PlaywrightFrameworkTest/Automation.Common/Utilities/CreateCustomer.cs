
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    public  class CreateCustomer
    {
        public static string GenerateName()
        {
            Random random = new Random();
            string[] nameList = { "Junior", "Blessing", "Gift", "Bandile", "Prince", "Siyabonga", "Lethabo", "liam", "Noah", "Oliver", "Emma", "Charlotte", "Amelia" };
            int RandomNumber = random.Next(1, nameList.Length);
            string customerName = nameList[RandomNumber];
            return customerName;
        }

        ///<summary>
        /// Generates an ID number from a random date 
        ///</summary>
        public static string GeneratePetName()
        {
            Random random = new Random();
            string[] nameList = { "Fluffy", "Jasper", "Woofy", "Snuggles", "Sushi", "Milky", "Chocolate", "Elvis", "Levi", "Eran", "Titan", "Terror", "Mur", "Dusty", "Scrappy,", "Scooby" };
            int RandomNumber = random.Next(1, nameList.Length);
            string petName = nameList[RandomNumber];
            return petName;
        }
    }
}
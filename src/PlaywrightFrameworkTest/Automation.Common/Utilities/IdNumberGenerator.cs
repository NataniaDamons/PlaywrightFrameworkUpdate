namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    public class IdNumberGenerator
    {
        private static readonly Random s_RandomNumberGenerator = new();
        /// <summary>
        /// Generates an ID number from a random date
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            DateTime randomDate = GenerateRandomDate();
            return Generate(randomDate);
        }

        /// <summary>
        /// Generates an ID number from the provided sate part (yyMMdd)
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static string Generate(DateTime dateOfBirth)
        {
            // Date of Birth. 1st 6 digits
            string dob = GetDate(dateOfBirth);

            // Get gender sequence
            string gender = GetGender();

            // Country is SA
            string countryind = "0";

            // Racial indicator
            string racialind = s_RandomNumberGenerator.Next(0, 2) == 0 ? "8" : "9";

            // Build string, remove quotes
            string finalId = dob.Trim('"') + gender.Trim('"') + countryind + racialind.Trim('"');

            int checkdigit = GetCheckDigit(finalId);

            return string.Concat(dob, gender, countryind, racialind, checkdigit);
        }

        private static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(s_RandomNumberGenerator.Next(range));
        }

        private static string GetDate(DateTime dateOfBirth)
        {
            // Date of Birth. 1st 6 digits
            return dateOfBirth.ToString("yyMMdd");
        }

        private static string GetGender()
        {
            string genderdigit, b;
            Random rand = new Random();

            // Get random gender indicator. 5 and above is male, below 5 is female
            genderdigit = Convert.ToString(rand.Next(0, 2) == 0 ? rand.Next(5, 9) : rand.Next(0, 4));

            for (int i = 0; i < 3; i++)
            {
                b = Convert.ToString(rand.Next(0, 9));
                genderdigit = genderdigit.Trim('"') + b.Trim('"');
            }

            return genderdigit;
        }

        private static int GetCheckDigit(string idnum)
        {
            int sumodd = 0, sumeven, n;

            // Odd elements
            for (int i = 0; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    n = idnum[i] - '0';
                    sumodd += n;
                }
            }

            string evenfield = "";
            // Even elements into field
            for (int i = 0; i < 12; i++)
            {
                if (i % 2 != 0)
                {
                    evenfield = evenfield + idnum[i];
                }
            }

            int num = int.Parse(evenfield);
            int num2 = num * 2;

            // Add up values of even elements
            sumeven = 0;
            while (num2 != 0)
            {
                sumeven += num2 % 10;
                num2 /= 10;
            }

            int totalsum = sumodd + sumeven;
            int lastdigit = (totalsum % 10);
            int checkdigit = 10 - lastdigit;

            // Check-digit cant be 10
            if (lastdigit == 0)
            {
                checkdigit = 0;
            }

            return checkdigit;
        }
    }
}
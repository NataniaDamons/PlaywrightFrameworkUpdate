using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlaywrightFrameworkTest;
using PlaywrightFrameworkTest.Automation;
using PlaywrightFrameworkTest.Automation.Common.Utilities;
using System.Collections.Generic;
using System.Diagnostics;

namespace PlaywrightFrameworkTest
{
    public class ScriptWithDataProvider : Automation.Common.Automation
    {
        public string name = CreateCustomer.GenerateName();
        public string ID = IdNumberGenerator.Generate();

        [Test]
        public async Task RunTest()
        {
            // Start writing script from here onwards
            await Page.GotoAsync("https://playwright.dev/dotnet");
            await Page.GotoAsync("https://www.google.com/");
        }

        [Test, TestCaseSource(typeof(DataProvider), nameof(DataProvider.GetNames))]
        public async Task TestNames(string name, int employeeId, string dob, string fname)
        {
            Debug.WriteLine($"Name: {name}, Employee ID: {employeeId}, DOB: {dob}, Fname: {fname}");
            await Page.GotoAsync("Google.com");
        }
    }
}
namespace PlaywrightFrameworkTest.Automation.Common.Utilities
{
    public static class TraceFileSetup
    {
        public static string SetupTraceFile()
        {
        //Adding the destination folder to where the browser instance should store 
        //Find the current directory that points to the Bin Folder
        //Create a substring that points to PlaywrightFrameworkTest
        string CurrentDirectory = Directory.GetCurrentDirectory();
        string ProjectName = "PlaywrightFrameworkTest";
        int index = CurrentDirectory.LastIndexOf(ProjectName);
        string projectDirectory = "";
        if (index != -1)
        {
            projectDirectory = CurrentDirectory.Substring(0, index + ProjectName.Length);
        }    
        //Create a directory for the trace files and login details to be stored
        Directory.CreateDirectory($"{projectDirectory}\\TraceFiles");
        return projectDirectory;
        }
    }
}
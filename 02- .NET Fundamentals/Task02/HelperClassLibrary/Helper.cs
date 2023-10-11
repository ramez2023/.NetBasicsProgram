using System;

namespace HelperClassLibrary
{
    // https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0
    public static class Helper
    {
        public static string GetRichName(string username)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-7.0
            // s: 2008-06-15T21:15:07
            return $"{DateTime.Now.ToString("s")} Hello, {username}!";
        }

        public static string GetErrorMessage()
        {
            return "Empty string, please enter valid name";
        }
    }
}
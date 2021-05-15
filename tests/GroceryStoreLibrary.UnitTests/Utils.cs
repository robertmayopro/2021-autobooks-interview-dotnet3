using System;
using System.IO;
using System.Reflection;
using NUnit.Compatibility;
using NUnit.Framework;

namespace GroceryStoreLibrary.UnitTests
{
    public static class Utils
    {
        public const string DatabaseFile = "database.json";

        public static string GetDatabaseSeedJson()
        {
            Type type = typeof(Utils);
            Assembly assembly = GetExecutingAssembly();
            using var s = assembly.GetManifestResourceStream(type, DatabaseFile);
            using var reader = new StreamReader(s);
            return reader.ReadToEnd();
        }

        public static string GetTempDir()
        {
            Assembly assembly = GetExecutingAssembly();
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataDir, assembly.GetName().Name);
        }

        private static Assembly GetExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }

    [SetUpFixture]
    public class TestSession
    {
        public static readonly Guid SessionId;
        public static readonly DateTime SessionStartDate;
        public static readonly string SessionName;
        public static readonly string TempDirectory;
        public static readonly string WorkingDirectory;
        
        static TestSession()
        {
            SessionId = Guid.NewGuid();
            SessionStartDate = DateTime.Now;
            SessionName = SessionStartDate.ToString("yyyy.MM.dd hh.mm.ss");
            TempDirectory = Utils.GetTempDir();
            WorkingDirectory = Path.Combine(TempDirectory, SessionName);
        }

    }
}

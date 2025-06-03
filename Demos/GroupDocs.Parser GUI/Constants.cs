using System;
using System.IO;

namespace GroupDocs.Parser.Gui
{
    static class Constants
    {
        public static string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public const string CompanyName = "GroupDocs";
        public const string ProductName = "Parser";
        public const string AppName = "Gui";
        public static string StorageBasePath = Path.Combine(LocalAppDataPath, CompanyName, ProductName, AppName);
        public static string SettingsFilePath = Path.Combine(StorageBasePath, "Settings.xml");
    }
}

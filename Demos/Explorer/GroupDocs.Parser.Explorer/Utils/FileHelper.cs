using System.IO;

namespace GroupDocs.Parser.Explorer.Utils
{
    class FileHelper
    {
        public static void EnsureFolderExists(string filePath)
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            Directory.CreateDirectory(directoryPath);
        }
    }
}

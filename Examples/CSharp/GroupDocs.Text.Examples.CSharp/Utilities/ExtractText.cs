using GroupDocs.Text;
using GroupDocs.Text.Extractors.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocs.Text_for_.NET.Utilities
{
    public class ExtractText
    {
        public ExtractText(string fileName, bool formatted)
        {
            //ExStart:ExtractText
            int linesPerPage = Console.WindowHeight;
            ExtractorFactory factory = new ExtractorFactory();

            TextExtractor extractor = formatted
                ? factory.CreateFormattedTextExtractor(fileName)
                : factory.CreateTextExtractor(fileName);
            if (extractor == null)
            {
                Console.WriteLine("The document's format is not supported");
                return;
            }

            try
            {
                string line = null;
                do
                {
                    Console.Clear();
                    Console.WriteLine("{0}", fileName);

                    int lineNumber = 0;
                    do
                    {
                        line = extractor.ExtractLine();
                        lineNumber++;
                        if (line != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    while (line != null && lineNumber < linesPerPage);

                    Console.WriteLine();
                    Console.WriteLine("Press Esc to exit or any other key to move to the next page");
                }
                while (line != null && Console.ReadKey().Key != ConsoleKey.Escape);
            }
            finally
            {
                extractor.Dispose();
            }
            //ExEnd:ExtractText
        }
        public static void ViewContentInConsole(string fileName)
        {
            //ExStart:ViewContentInConsole
            //get file actual path
            String filePath = Common.GetFilePath(fileName);
            ExtractText extractor = new ExtractText(filePath, filePath.Length > 1 && filePath == "/f");
            //ExEnd:ViewContentInConsole
        }

    }
}

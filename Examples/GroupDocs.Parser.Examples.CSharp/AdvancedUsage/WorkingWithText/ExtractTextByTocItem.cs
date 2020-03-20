using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GroupDocs.Parser.Data;

namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    /// <summary>
    /// This example how to extract a text by the an item of table of contents.
    /// </summary>
    static class ExtractTextByTocItem
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdfWithToc))
            {
                // Get table of contents
                IEnumerable<TocItem> tocItems = parser.GetToc();

                // Check if toc extraction is supported
                if (tocItems == null)
                {
                    Console.WriteLine("Table of contents extraction isn't supported");
                }

                // Iterate over items
                foreach (TocItem tocItem in tocItems)
                {
                    // Print the text of the chapter
                    using (TextReader reader = tocItem.ExtractText())
                    {
                        Console.WriteLine("----");
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.EPUB
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract a text by an item of table of contents.
    /// </summary>
    static class ExtractTableOfContents
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleEpub))
            {
                // Get table of contents
                IEnumerable<TocItem> tocItems = parser.GetToc();

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

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract table of contents from EPUB ebook.
    /// </summary>
    static class ExtractTableOfContents
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleEpub))
            {
                // Check if text extraction is supported
                if (!parser.Features.Text)
                {
                    Console.WriteLine("Text extraction isn't supported.");
                    return;
                }
                // Check if toc extraction is supported
                if (!parser.Features.Toc)
                {
                    Console.WriteLine("Toc extraction isn't supported.");
                    return;
                }
                // Get table of contents
                IEnumerable<TocItem> toc = parser.GetToc();
                // Iterate over items
                foreach (TocItem i in toc)
                {
                    // Print the Toc text
                    Console.WriteLine(i.Text);

                    // Check if page index has a value
                    if (i.PageIndex == null)
                    {
                        continue;
                    }

                    // Extract a page text
                    using (TextReader reader = parser.GetText(i.PageIndex.Value))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

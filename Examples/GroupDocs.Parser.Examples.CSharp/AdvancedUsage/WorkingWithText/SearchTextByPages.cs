// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to search a text by pages
    /// </summary>
    static class SearchTextByPages
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdf))
            {
                // Search a keyword with page numbers
                IEnumerable<SearchResult> sr = parser.Search("lorem", new SearchOptions(false, false, false, true));
                // Check if search is supported
                if (sr == null)
                {
                    Console.WriteLine("Search isn't supported");
                    return;
                }

                // Iterate over search results
                foreach (SearchResult s in sr)
                {
                    // Print an index, page number and found text:
                    Console.WriteLine(string.Format("At {0} (page {1}): {2}", s.Position, s.PageIndex, s.Text));
                }
            }
        }
    }
}

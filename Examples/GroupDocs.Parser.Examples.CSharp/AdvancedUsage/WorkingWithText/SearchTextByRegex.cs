// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to search with a regular expression in a document.
    /// </summary>
    static class SearchTextByRegex
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdf))
            {
                // Search with a regular expression with case matching
                IEnumerable<SearchResult> sr = parser.Search("[0-9]+", new SearchOptions(true, false, true));
                // Check if search is supported
                if (sr == null)
                {
                    Console.WriteLine("Search isn't supported");
                    return;
                }

                // Iterate over search results
                foreach (SearchResult s in sr)
                {
                    // Print an index and found text:
                    Console.WriteLine(string.Format("At {0}: {1}", s.Position, s.Text));
                }
            }
        }
    }
}

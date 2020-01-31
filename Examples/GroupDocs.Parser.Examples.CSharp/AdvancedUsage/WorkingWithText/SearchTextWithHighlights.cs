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
    /// This example shows how to search a text with highlights.
    /// </summary>
    static class SearchTextWithHighlights
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdf))
            {
                HighlightOptions highlightOptions = new HighlightOptions(15);
                // Search a keyword:
                IEnumerable<SearchResult> sr = parser.Search("lorem", new SearchOptions(true, false, false, highlightOptions));
                // Check if search is supported
                if (sr == null)
                {
                    Console.WriteLine("Search isn't supported");
                    return;
                }

                // Iterate over search results
                foreach (SearchResult s in sr)
                {
                    // Print the found text and highlights: 
                    Console.WriteLine(string.Format("{0}{1}{2}", s.LeftHighlightItem.Text, s.Text, s.RightHighlightItem.Text));
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2022 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to find a keyword in Microsoft Office PowerPoint presentation.
    /// </summary>
    static class SearchTextByKeyword
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePptx))
            {
                // Search a keyword:
                IEnumerable<SearchResult> sr = parser.Search("TEST");

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

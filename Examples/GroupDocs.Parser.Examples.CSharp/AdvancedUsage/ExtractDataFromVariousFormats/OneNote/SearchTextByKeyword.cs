// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.OneNote
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to find a keyword in Microsoft OneNote section.
    /// </summary>
    static class SearchTextByKeyword
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SearchTextByKeyword : This example shows how to find a keyword in Microsoft OneNote section.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleOne))
            {
                // Search a keyword:
                IEnumerable<SearchResult> sr = parser.Search("Age");

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

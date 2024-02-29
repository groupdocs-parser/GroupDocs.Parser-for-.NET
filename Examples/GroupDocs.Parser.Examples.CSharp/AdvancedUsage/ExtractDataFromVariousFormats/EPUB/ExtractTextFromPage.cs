// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.EPUB
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a text from the page of EPUB e-book.
    /// </summary>
    static class ExtractTextFromPage
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleEpub))
            {
                // Get the document info
                IDocumentInfo documentInfo = parser.GetDocumentInfo();

                // Iterate over pages
                for (int p = 0; p < documentInfo.PageCount; p++)
                {
                    // Print a page number 
                    Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.PageCount));

                    // Extract a text into the reader
                    using (TextReader reader = parser.GetText(p))
                    {
                        // Print a text from the document
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a raw text from a document page:
    /// </summary>
    static class ExtractTextFromPageInRawMode
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdf))
            {
                // Check if the document supports text extraction
                if (!parser.Features.Text)
                {
                    Console.WriteLine("Document isn't supports text extraction.");
                    return;
                }
                // Get the document info
                IDocumentInfo documentInfo = parser.GetDocumentInfo();
                // Check if the document has pages
                if (documentInfo == null || documentInfo.RawPageCount == 0)
                {
                    Console.WriteLine("Document hasn't pages.");
                    return;
                }
                // Iterate over pages
                for (int p = 0; p < documentInfo.RawPageCount; p++)
                {
                    // Print a page number 
                    Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.RawPageCount));
                    // Extract a text into the reader
                    using (TextReader reader = parser.GetText(p, new TextOptions(true)))
                    {
                        // Print a text from the document
                        // We ignore null-checking as we have checked text extraction feature support earlier
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

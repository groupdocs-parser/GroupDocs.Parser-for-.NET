// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText.WorkingWithFormattedText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a document page text as Markdown text.
    /// </summary>
    static class ExtractFormattedTextFromDocumentPage
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Check if the document supports formatted text extraction
                if (!parser.Features.FormattedText)
                {
                    Console.WriteLine("Document isn't supports formatted text extraction.");
                    return;
                }

                // Get the document info
                IDocumentInfo documentInfo = parser.GetDocumentInfo();
                // Check if the document has pages
                if (documentInfo.PageCount == 0)
                {
                    Console.WriteLine("Document hasn't pages.");
                    return;
                }

                // Iterate over pages
                for (int p = 0; p < documentInfo.PageCount; p++)
                {
                    // Print a page number 
                    Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.PageCount));
                    // Extract a formatted text into the reader
                    using (TextReader reader = parser.GetFormattedText(p, new FormattedTextOptions(FormattedTextMode.Markdown)))
                    {
                        // Print a formatted text from the document
                        // We ignore null-checking as we have checked formatted text extraction feature support earlier
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

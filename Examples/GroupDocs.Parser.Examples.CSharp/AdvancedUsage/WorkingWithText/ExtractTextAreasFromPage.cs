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
    /// This example shows how to extract text areas from a document page.
    /// </summary>
    static class ExtractTextAreasFromPage
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Check if the document supports text areas extraction
                if (!parser.Features.TextAreas)
                {
                    Console.WriteLine("Document isn't supports text areas extraction.");
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
                for (int pageIndex = 0; pageIndex < documentInfo.PageCount; pageIndex++)
                {
                    // Print a page number 
                    Console.WriteLine(string.Format("Page {0}/{1}", pageIndex + 1, documentInfo.PageCount));

                    // Iterate over page text areas
                    // We ignore null-checking as we have checked text areas extraction feature support earlier
                    foreach (PageTextArea a in parser.GetTextAreas(pageIndex))
                    {
                        // Print a rectangle and text area value:
                        Console.WriteLine(string.Format("R: {0}, Text: {1}", a.Rectangle, a.Text));
                    }
                }
            }
        }
    }
}

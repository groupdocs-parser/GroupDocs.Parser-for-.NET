// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithHyperlinks
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract hyperlinks from the document page.
    /// </summary>
    static class ExtractHyperlinksFromDocumentPage
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.HyperlinksPdf))
            {
                // Check if the document supports hyperlink extraction
                if (!parser.Features.Hyperlinks)
                {
                    Console.WriteLine("Document isn't supports hyperlink extraction.");
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

                    // Extract hyperlinks from the document page
                    IEnumerable<PageHyperlinkArea> hyperlinks = parser.GetHyperlinks(pageIndex);

                    // Iterate over hyperlinks
                    foreach (PageHyperlinkArea h in hyperlinks)
                    {
                        // Print the hyperlink text
                        Console.WriteLine(h.Text);
                        // Print the hyperlink URL
                        Console.WriteLine(h.Url);

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithImages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract images from a document page.
    /// </summary>
    static class ExtractImagesFromDocumentPage
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleImagesPdf))
            {
                // Check if the document supports images extraction
                if (!parser.Features.Images)
                {
                    Console.WriteLine("Document isn't supports images extraction.");
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
                    // Iterate over images
                    // We ignore null-checking as we have checked images extraction feature support earlier
                    foreach (PageImageArea image in parser.GetImages(pageIndex))
                    {
                        // Print a rectangle and image type
                        Console.WriteLine(string.Format("R: {0}, Text: {1}", image.Rectangle, image.FileType));
                    }
                }
            }
        }
    }
}

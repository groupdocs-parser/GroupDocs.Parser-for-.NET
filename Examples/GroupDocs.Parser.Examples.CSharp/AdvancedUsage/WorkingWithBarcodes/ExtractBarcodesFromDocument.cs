// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithBarcodes
{
    using GroupDocs.Parser.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This example shows how to extract barcodes from a document.
    /// </summary>
    static class ExtractBarcodesFromDocument
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdfWithBarcodes))
            {
                // Check if the document supports barcodes extraction
                if (!parser.Features.Barcodes)
                {
                    Console.WriteLine("Document doesn't support barcodes extraction.");
                    return;
                }

                // Extract barcodes from the document.
                IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes();

                // Iterate over barcodes
                foreach (PageBarcodeArea barcode in barcodes)
                {
                    // Print the page index
                    Console.WriteLine("Page: " + barcode.Page.Index.ToString());
                    // Print the barcode value
                    Console.WriteLine("Value: " + barcode.Value);
                }
            }
        }
    }
}

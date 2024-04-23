// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithBarcodes
{
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This example shows how to extract corrupted barcodes from a document.
    /// </summary>
    static class ExtractBarcodesFromDocumentCorrupted
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleCorruptedBarcodes))
            {
                // Check if the document supports barcodes extraction
                if (!parser.Features.Barcodes)
                {
                    Console.WriteLine("Document doesn't support barcodes extraction.");
                    return;
                }

                // Create the options which are used for barcodes extraction
                // The full constructor is used to set AllowIncorrectBarcodes property
                BarcodeOptions options = new BarcodeOptions(null, QualityMode.Low, QualityMode.Low, null, true, "pdf417", "QR");

                // Extract barcodes from the document.
                IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes(options);

                // Iterate over barcodes
                foreach (PageBarcodeArea barcode in barcodes)
                {
                    // Print the page index
                    Console.WriteLine("Page: " + barcode.Page.Index.ToString());
                    // Print the barcode value
                    Console.WriteLine("Value: " + barcode.Value);
                    // Print the confidence:
                    Console.WriteLine("Confidence: " + barcode.Confidence.ToString());
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithBarcodes
{
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This example shows how to extract barcodes from the upper-right corner.
    /// </summary>
    static class ExtractBarcodesFromDocumentPageArea
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractBarcodesFromDocumentPageArea : This example shows how to extract barcodes from the upper-right corner.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdfWithBarcodes))
            {
                // Check if the document supports barcodes extraction
                if (!parser.Features.Barcodes)
                {
                    Console.WriteLine("Document doesn't support barcodes extraction.");
                    return;
                }

                // Create the options which are used for barcodes extraction
                BarcodeOptions options = new BarcodeOptions(new Rectangle(new Point(590, 80), new Size(150, 150)));
                // Extract barcodes from the upper-right corner.
                IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes(options);

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

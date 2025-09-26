// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>

namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Exceptions;
    using GroupDocs.Parser.Export;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to export data to JSON file.
    /// </summary>
    static class Export
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Export : This example shows how to export data to JSON file.\n");


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
                BarcodeOptions options = new BarcodeOptions(QualityMode.Low, QualityMode.Low, "QR");

                // Extract barcodes from the document
                IEnumerable<PageBarcodeArea> barcodes = parser.GetBarcodes(options);

                // Export data to "data.json" file
                barcodes.ExportAsJson("data.json");
            }
        }
    }
}
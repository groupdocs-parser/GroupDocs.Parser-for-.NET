// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2022 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.UsingOcr
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Aspose.OCR;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a text from the image file.
    /// </summary>
    static class OcrUsageBasicsText
    {
        public static void Run()
        {
            // Create an instance of ParserSettings class with OCR Connector
            ParserSettings settings = new ParserSettings(new AsposeOcrOnPremise());

            // Create an instance of Parser class with settings
            using (Parser parser = new Parser(Constants.SampleScan, settings))
            {
                // Create an instance of TextOptions to use OCR
                TextOptions options = new TextOptions(false, true);
                // Extract a text using OCR
                using(TextReader reader = parser.GetText(options))
                {
                    // Print a text or 'not supported' message
                    Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
                }
            }
        }
    }
}

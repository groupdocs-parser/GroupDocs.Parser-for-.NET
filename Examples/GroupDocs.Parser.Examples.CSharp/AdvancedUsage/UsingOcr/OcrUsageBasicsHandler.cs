// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
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
    /// This example shows how to handle warning messages.
    /// </summary>
    static class OcrUsageBasicsHandler
    {
        public static void Run()
        {
            // Create an instance of ParserSettings class with OCR Connector
            ParserSettings settings = new ParserSettings(new AsposeOcrOnPremise());

            // Create an instance of Parser class with settings
            using (Parser parser = new Parser(Constants.SampleScan, settings))
            {
                // Create an instance of OcrEventHandler to handle warnings
                OcrEventHandler handler = new OcrEventHandler();

                // Create an instance of OcrOptions to set a handler
                OcrOptions ocrOptions = new OcrOptions(handler);

                // Create an instance of TextOptions to use OCR
                TextOptions options = new TextOptions(false, true, ocrOptions);
                // Extract a text using OCR
                using (TextReader reader = parser.GetText(options))
                {
                    // Print a text or 'not supported' message
                    Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
                }

                if (handler.HasWarnings)
                {
                    Console.WriteLine("The following warnings occur while text recognition:");

                    foreach (string w in handler.Warnings)
                    {
                        Console.WriteLine("\\t* " + w);
                    }
                }
                else
                {
                    Console.WriteLine("Text recognition was performed without any warning.");
                }
            }
        }
    }
}

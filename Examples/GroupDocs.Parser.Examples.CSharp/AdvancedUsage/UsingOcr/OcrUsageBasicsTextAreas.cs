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
    /// This example shows how to extract text areas from the image file.
    /// </summary>
    static class OcrUsageBasicsTextAreas
    {
        public static void Run()
        {            
            // Create an instance of ParserSettings class with OCR Connector
            ParserSettings settings = new ParserSettings(new AsposeOcrOnPremise());

            // Create an instance of Parser class with settings
            using (Parser parser = new Parser(Constants.SampleScan, settings))
            {
                // Create an instance of PageTextAreaOptions to use OCR
                PageTextAreaOptions options = new PageTextAreaOptions(true);
              
                // Extract text areas
                IEnumerable<PageTextArea> areas = parser.GetTextAreas(options);
                
                // Check if text areas extraction is supported
                if (areas == null)
                {
                    Console.WriteLine("Text areas extraction isn't supported");
                    return;
                }

                // Iterate over text areas
                foreach (PageTextArea a in areas)
                {
                    // Print a text, position and size for an each text area
                    Console.WriteLine(a.Text);
                    Console.WriteLine("\tPosition: ({0}; {1})", a.Rectangle.Left, a.Rectangle.Top);
                    Console.WriteLine("\tSize: ({0}; {1})", a.Rectangle.Size.Width, a.Rectangle.Size.Height);
                }
            }
        }
    }
}

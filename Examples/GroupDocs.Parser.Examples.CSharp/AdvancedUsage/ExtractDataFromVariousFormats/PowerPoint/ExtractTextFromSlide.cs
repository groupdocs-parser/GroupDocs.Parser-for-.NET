// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a text from the slide of Microsoft Office PowerPoint presentation.
    /// </summary>
    static class ExtractTextFromSlide
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePptx))
            {
                // Get the document info
                IDocumentInfo documentInfo = parser.GetDocumentInfo();

                // Iterate over slides
                for (int p = 0; p < documentInfo.PageCount; p++)
                {
                    // Print a slide number 
                    Console.WriteLine(string.Format("Slide {0}/{1}", p + 1, documentInfo.PageCount));

                    // Extract a text into the reader
                    using (TextReader reader = parser.GetText(p))
                    {
                        // Print a text from the presentation
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

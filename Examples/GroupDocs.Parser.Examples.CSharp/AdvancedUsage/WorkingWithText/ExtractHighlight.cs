// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a highlight that contains 3 words.
    /// </summary>
    static class ExtractHighlight
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdf))
            {
                // Extract a highlight:
                HighlightItem hl = parser.GetHighlight(2, true, new HighlightOptions(3));
                // Check if highlight extraction is supported
                if (hl == null)
                {
                    Console.WriteLine("Highlight extraction isn't supported");
                    return;
                }
                // Print an extracted highlight
                Console.WriteLine(string.Format("At {0}: {1}", hl.Position, hl.Text));
            }
        }
    }
}

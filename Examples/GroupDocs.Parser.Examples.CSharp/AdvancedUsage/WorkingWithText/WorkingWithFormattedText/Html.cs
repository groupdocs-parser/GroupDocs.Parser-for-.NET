// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText.WorkingWithFormattedText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a document text as HTML text.
    /// </summary>
    static class Html
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Extract a formatted text into the reader
                using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
                {
                    // Print a formatted text from the document
                    // If formatted text extraction isn't supported, a reader is null
                    Console.WriteLine(reader == null ? "Formatted text extraction isn't suppported" : reader.ReadToEnd());
                }
            }
        }
    }
}

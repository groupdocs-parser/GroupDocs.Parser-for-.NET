// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Excel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to extract a text from Microsoft Office Excel spreadsheet as HTML.
    /// </summary>
    static class ExtractTextAsHtml
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                // Extract a formatted text into the reader
                using (TextReader reader = parser.GetFormattedText(new FormattedTextOptions(FormattedTextMode.Html)))
                {
                    // Print a formatted text from the spreadsheet
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}

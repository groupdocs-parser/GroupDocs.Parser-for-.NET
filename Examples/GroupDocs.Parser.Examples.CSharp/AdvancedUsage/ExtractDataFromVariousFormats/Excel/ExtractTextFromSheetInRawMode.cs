// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
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
    /// This example shows how to extract a raw text from the page of Microsoft Office Excel spreadsheet.
    /// </summary>
    static class ExtractTextFromSheetInRawMode
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                // Get the document info
                IDocumentInfo documentInfo = parser.GetDocumentInfo();

                // Iterate over sheets
                for (int p = 0; p < documentInfo.RawPageCount; p++)
                {
                    // Print a page number 
                    Console.WriteLine(string.Format("Page {0}/{1}", p + 1, documentInfo.RawPageCount));

                    // Extract a text into the reader
                    using (TextReader reader = parser.GetText(p, new TextOptions(true)))
                    {
                        // Print a text from the spreadsheet
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

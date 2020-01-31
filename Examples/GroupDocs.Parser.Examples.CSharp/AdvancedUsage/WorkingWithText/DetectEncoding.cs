// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.WorkingWithText
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example shows how to detect the encoding of the document.
    /// </summary>
    static class DetectEncoding
    {
        public static void Run()
        {
            // Create an instance of LoadOptions class with the default ANSI encoding.
            // This encoding is returned for ANSI text documents.
            LoadOptions loadOptions = new LoadOptions(FileFormat.WordProcessing, null, null, Encoding.GetEncoding(1251));
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleText, loadOptions))
            {
                // Get the document info
                TextDocumentInfo info = parser.GetDocumentInfo() as TextDocumentInfo;
                // Check if it's the document info of a plain text document
                if (info == null)
                {
                    Console.WriteLine("Isn't a plain text document");
                    return;
                }

                // Print the encoding
                Console.WriteLine("Encoding: " + info.Encoding.WebName);
            }
        }
    }
}

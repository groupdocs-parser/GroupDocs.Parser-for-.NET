// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This example shows how to load a document from the local disk.
    /// </summary>
    static class LoadDocumentFromLocalDisk
    {
        public static void Run()
        {
            // Set the filePath
            string filePath = Constants.SamplePdf;
            // Create an instance of Parser class with the filePath
            using (Parser parser = new Parser(filePath))
            {
                // Extract a text into the reader
                using (TextReader reader = parser.GetText())
                {
                    // Print a text from the document
                    // If text extraction isn't supported, a reader is null
                    Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
                }
            }
        }
    }
}

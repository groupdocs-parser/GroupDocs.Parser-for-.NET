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
    /// This example shows how to load a document from the stream.
    /// </summary>
    static class LoadDocumentFromStream
    {
        public static void Run()
        {
            // Create the stream
            using (Stream stream = File.OpenRead(Constants.SamplePdf))
            {
                // Create an instance of Parser class with the stream
                using (Parser parser = new Parser(stream))
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
}

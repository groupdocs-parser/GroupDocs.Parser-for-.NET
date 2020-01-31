// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.QuickStart
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This example shows how to extract a text form a document.
    /// </summary>
    static class HelloWorld
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Extract a text to the reader
                using (TextReader reader = parser.GetText())
                {
                    // Print an extracted text (or "not supported" message)
                    Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
                }
            }
        }
    }
}

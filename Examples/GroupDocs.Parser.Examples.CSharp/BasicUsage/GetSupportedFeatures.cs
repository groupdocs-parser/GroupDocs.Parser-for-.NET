// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This example shows how to check if text extraction feature is supported.
    /// </summary>
    static class GetSupportedFeatures
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleZip))
            {
                // Check if text extraction is supported for the document
                if (!parser.Features.Text)
                {
                    Console.WriteLine("Text extraction isn't supported");
                    return;
                }

                // Extract a text from the document
                using (TextReader reader = parser.GetText())
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }

    }
}

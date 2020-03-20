// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.Loading
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Options;

    /// <summary>
    /// This example how to specify the file format when loading the document.
    /// </summary>
    static class LoadingSpecificFileFormats
    {
        public static void Run()
        {
            using (Stream stream = File.OpenRead(Constants.SampleMd))
            {
                // Create an instance of Parser class for markdown document
                using (Parser parser = new Parser(stream, new LoadOptions(Options.FileFormat.Markup)))
                {
                    // Check if text extraction is supported
                    if (!parser.Features.Text)
                    {
                        Console.WriteLine("Text extraction isn't supported.");
                        return;
                    }
                    using (TextReader reader = parser.GetText())
                    {
                        // Print the document text
                        // Markdown is detected; text without special symbols is printed
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}

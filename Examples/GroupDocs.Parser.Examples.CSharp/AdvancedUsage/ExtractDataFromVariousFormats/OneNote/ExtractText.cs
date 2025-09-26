// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2025 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.OneNote
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract a text from Microsoft OneNote section.
    /// </summary>
    static class ExtractText
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # ExtractText : This example shows how to extract a text from Microsoft OneNote section.\n");


            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleOne))
            {
                // Extract a text into the reader
                using (TextReader reader = parser.GetText())
                {
                    // Print a text from the section
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}

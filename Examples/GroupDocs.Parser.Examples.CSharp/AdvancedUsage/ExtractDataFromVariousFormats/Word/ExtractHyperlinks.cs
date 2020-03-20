// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Word
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract hyperlinks from Microsoft Office Word document.
    /// </summary>
    static class ExtractHyperlinks
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleHyperlinksDocx))
            {
                // Get the reader object for the document XML representation
                using (XmlReader reader = parser.GetStructure())
                {
                    // Iterate over the document
                    while (reader.Read())
                    {
                        // If it is the start tag of the hyperlink
                        if (reader.IsStartElement() && reader.Name == "hyperlink")
                        {
                            // Print the link attribute
                            Console.WriteLine(reader.GetAttribute("link"));
                        }
                    }
                }
            }
        }
    }
}

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2020 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.BasicUsage
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract metadata from a document.
    /// </summary>
    static class ExtractImagesFromDocuments
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleDocx))
            {
                // Extract metadata from the document
                IEnumerable<MetadataItem> metadata = parser.GetMetadata();
                // Check if metadata extraction is supported
                if (metadata == null)
                {
                    Console.WriteLine("Metatada extraction isn't supported");
                }

                // Iterate over metadata items
                foreach (MetadataItem item in metadata)
                {
                    // Print an item name and value
                    Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Value));
                }
            }
        }
    }
}

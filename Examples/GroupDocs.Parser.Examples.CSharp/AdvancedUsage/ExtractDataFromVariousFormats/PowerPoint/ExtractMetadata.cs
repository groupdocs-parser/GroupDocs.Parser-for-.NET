// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2022 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.PowerPoint
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract metadata from Microsoft Office PowerPoint presentation.
    /// </summary>
    static class ExtractMetadata
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePptx))
            {
                // Extract metadata from the presentation
                IEnumerable<MetadataItem> metadata = parser.GetMetadata();

                // Iterate over metadata items
                foreach (MetadataItem item in metadata)
                {
                    // Print the item name and value
                    Console.WriteLine(string.Format("{0}: {1}", item.Name, item.Value));
                }
            }
        }
    }
}

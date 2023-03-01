// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2023 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract metadata from Microsoft Office Excel spreadsheet.
    /// </summary>
    static class ExtractMetadata
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleXlsx))
            {
                // Extract metadata from the spreadsheet
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

// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Email
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GroupDocs.Parser.Data;

    /// <summary>
    /// This example shows how to extract metadata from an email.
    /// </summary>
    static class ExtractMetadata
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SampleMsg))
            {
                // Extract metadata from the email
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

﻿// <copyright company="Aspose Pty Ltd">
//   Copyright (C) 2011-2024 GroupDocs. All Rights Reserved.
// </copyright>
namespace GroupDocs.Parser.Examples.CSharp.AdvancedUsage.ExtractDataFromVariousFormats.Pdf
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GroupDocs.Parser.Data;
    using GroupDocs.Parser.Exceptions;

    /// <summary>
    /// This example shows how to extract a text from PDF Portfolios.
    /// </summary>
    static class ExtractAttachmentsFromPdfPortfolios
    {
        public static void Run()
        {
            // Create an instance of Parser class
            using (Parser parser = new Parser(Constants.SamplePdfPortfolio))
            {
                // Extract attachments from the container
                IEnumerable<ContainerItem> attachments = parser.GetContainer();
                // Check if container extraction is supported
                if (attachments == null)
                {
                    Console.WriteLine("Container extraction isn't supported");
                }

                // Iterate over zip entities
                foreach (ContainerItem item in attachments)
                {
                    // Print the file path
                    Console.WriteLine(item.FilePath);

                    // Print metadata
                    foreach (MetadataItem metadata in item.Metadata)
                    {
                        Console.WriteLine(string.Format("{0}: {1}", metadata.Name, metadata.Value));
                    }

                    try
                    {
                        // Create Parser object for the zip entity content
                        using (Parser attachmentParser = item.OpenParser())
                        {
                            // Extract an zip entity text
                            using (TextReader reader = attachmentParser.GetText())
                            {
                                Console.WriteLine(reader == null ? "No text" : reader.ReadToEnd());
                            }
                        }
                    }
                    catch (UnsupportedDocumentFormatException)
                    {
                        Console.WriteLine("Isn't supported.");
                    }
                }
            }
        }
    }
}
